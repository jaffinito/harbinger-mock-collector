using Harbinger.Models;
using Harbinger.Models.Connect;
using Harbinger.Models.SpanEvents;
using Newtonsoft.Json;

namespace Harbinger
{
    internal static class ConnectMethodHandler
	{
		private static string _localIP;

		public static ILogger Logger { get; set; }

		public static ReturnValue HandleConnection(string method, string licenseKey, string protocolVersion, string payload)
		{
			switch (method)
			{
				case "preconnect":
					return PreConnect(payload);
				case "connect":
					return Connect(payload);
				case "metric_data":
					return MetricData(payload);
				case "agent_settings":
					return new ReturnValue("");
				case "get_agent_commands":
					return new ReturnValue("");
				case "analytic_event_data":
					return AnalyticEventData(payload);
				case "agent_command_results":
					return new ReturnValue("");
				case "custom_event_data":
					return CustomEventData(payload);
				case "error_data":
					return ErrorData(payload);
				case "error_event_data":
					return ErrorEventData(payload);
				case "profile_data":
					return new ReturnValue("");
				case "queue_ping_command":
					return new ReturnValue("");
				case "shutdown":
					return new ReturnValue("");
				case "sql_trace_data":
					return new ReturnValue("");
				case "transaction_sample_data":
					return TransactionSampleData(payload);
				case "update_loaded_modules":
					return new ReturnValue("");
				case "span_event_data":
					return SpanEventData(payload);
				case "log_event_data":
					return LogEventData(payload);
			}

			LoggerAdapter.Instance.WriteLine($"Method not found '{method}'");
			return new ReturnValue("");
		}

		private static ReturnValue PreConnect(string payload)
		{
			return new ReturnValue(new PreConnectResponse { RedirectHost = "localhost" });
		}

		private static ReturnValue Connect(string payload)
		{
			DataStore.Instance.MetricData.AddGeneratedUnscopedMetric("Instance/connects");
			var connection = JsonConvert.DeserializeObject<List<ConnectMethodRequest>>(payload) 
				?? new List<ConnectMethodRequest> { new ConnectMethodRequest() };
			DataStore.Instance.ConnectRequest = connection[0] ;
			return new ReturnValue(PayloadHelpers.ConnectReplyMock(1234));
		}

		private static ReturnValue MetricData(string payload)
		{
			var data = JsonConvert.DeserializeObject<List<object>>(payload);
			DataStore.Instance.RawMetricData.AddMetricData(data);
			DataStore.Instance.MetricData.Add(data);
			return new ReturnValue("");
		}

		private static ReturnValue SpanEventData(string payload)
		{
			var spanEventData = new SpanEventData(payload);
			DataStore.Instance.SpanEventData.Add(spanEventData.AgentRunId, spanEventData);
			return new ReturnValue("");
		}

		private static ReturnValue LogEventData(string payload)
		{
			var data = JsonConvert.DeserializeObject<List<object>>(payload);
			return new ReturnValue("");
		}

		private static ReturnValue ErrorEventData(string payload)
		{
			var data = JsonConvert.DeserializeObject<List<object>>(payload);
			return new ReturnValue("");
		}

		private static ReturnValue ErrorData(string payload)
		{
			var data = JsonConvert.DeserializeObject<List<object>>(payload);
			return new ReturnValue("");
		}

		private static ReturnValue TransactionSampleData(string payload)
		{
			var data = JsonConvert.DeserializeObject<List<object>>(payload);
			return new ReturnValue("");
		}

		private static ReturnValue CustomEventData(string payload)
		{
			var data = JsonConvert.DeserializeObject<List<object>>(payload);
			return new ReturnValue("");
		}

		private static ReturnValue AnalyticEventData(string payload)
		{
			var data = JsonConvert.DeserializeObject<List<object>>(payload);
			return new ReturnValue("");
		}
	}
}
