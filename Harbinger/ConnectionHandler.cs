using Harbinger.Models;
using Harbinger.Models.Connect;
using Harbinger.Models.Events;
using Newtonsoft.Json;

namespace Harbinger
{
    internal static class ConnectionHandler
	{
		public static ILogger Logger { get; set; }

		public static ReturnValue HandleConnection(string method, string licenseKey, string protocolVersion, string payload)
		{
			var guid = Guid.NewGuid();
			var returnValue = new ReturnValue("");

			try
            {
				LoggerAdapter.Instance.WriteLine($"Request {guid} received for'{method}'");

				switch (method)
				{
					case "preconnect":
						returnValue = PreConnect(payload);
						break;
					case "connect":
						returnValue = Connect(payload);
						break;
					case "metric_data":
						returnValue = MetricData(payload);
						break;
					case "agent_settings":
						break;
					case "get_agent_commands":
						break;
					case "analytic_event_data":
						returnValue = TransactionEventData(payload);
						break;
					case "agent_command_results":
						break;
					case "custom_event_data":
						returnValue = CustomEventData(payload);
						break;
					case "error_data":
						returnValue = TracedError(payload);
						break;
					case "error_event_data":
						returnValue = ErrorEventData(payload);
						break;
					case "profile_data":
						break;
					case "queue_ping_command":
						break;
					case "shutdown":
						break;
					case "sql_trace_data":
						break;
					case "transaction_sample_data":
						returnValue = TransactionSampleData(payload);
						break;
					case "update_loaded_modules":
						break;
					case "span_event_data":
						returnValue = SpanEventData(payload);
						break;
					case "log_event_data":
						returnValue = LogEventData(payload);
						break;
					default:
						LoggerAdapter.Instance.WriteLine($"Method not found '{method}'");
						break;
				}
			}
            catch (Exception ex)
            {
				LoggerAdapter.Instance.Error(ex, guid.ToString());
			}
            finally
            {
				LoggerAdapter.Instance.WriteLine($"Request {guid} completed for '{method}'");
			}

			return returnValue;
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
			return new ReturnValue(PayloadHelpers.ConnectReplyMock(DataStore.Instance.ConnectRequest.AppName[0]));
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
			var spanEventData = new EventData(payload);
			DataStore.Instance.SpanEventData.Merge(spanEventData.AgentRunId, spanEventData);
			return new ReturnValue("");
		}

		private static ReturnValue TransactionEventData(string payload)
		{
			var transactionEventData = new EventData(payload);
			DataStore.Instance.TransactionEventData.Merge(transactionEventData.AgentRunId, transactionEventData);
			return new ReturnValue("");
		}

		private static ReturnValue ErrorEventData(string payload)
		{
			var errorEventData = new EventData(payload);
			DataStore.Instance.ErrorEventData.Merge(errorEventData.AgentRunId, errorEventData);
			return new ReturnValue("");
		}

		private static ReturnValue CustomEventData(string payload)
		{
			var customEventData = new CustomEventData(payload);
			DataStore.Instance.CustomEventData.Merge(customEventData.AgentRunId, customEventData);
			return new ReturnValue("");
		}

		private static ReturnValue TracedError(string payload)
		{
			var errorTraceData = new ErrorTraceData(payload);
			DataStore.Instance.ErrorTraceData.Merge(errorTraceData.AgentRunId, errorTraceData);
			return new ReturnValue("");
		}

		private static ReturnValue LogEventData(string payload)
		{
			var logEventData = new LogEventData(payload);
			DataStore.Instance.LogEventData.Merge(logEventData.AgentRunId, logEventData);
			return new ReturnValue("");
		}

		private static ReturnValue TransactionSampleData(string payload)
		{
			var transactionSampleData = new TransactionSampleData(payload);
			DataStore.Instance.TransactionSampleData.Merge(transactionSampleData.AgentRunId, transactionSampleData);
			return new ReturnValue("");
		}
	}
}
