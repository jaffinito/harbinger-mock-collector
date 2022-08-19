using Harbinger.Models;
using Harbinger.Models.Connect;
using Harbinger.Models.Events;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using Newtonsoft.Json;
using System.Text;

namespace Harbinger
{
    internal static class ConnectMethodHandler
	{
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
					return TransactionEventData(payload);
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
			return new ReturnValue(PayloadHelpers.ConnectReplyMock("fred"));
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
			DataStore.Instance.SpanEventData.Add(spanEventData.AgentRunId, spanEventData);
			return new ReturnValue("");
		}

		private static ReturnValue TransactionEventData(string payload)
		{
			var transactionEventData = new EventData(payload);
			DataStore.Instance.TransactionEventData.Add(transactionEventData.AgentRunId, transactionEventData);
			return new ReturnValue("");
		}

		private static ReturnValue LogEventData(string payload)
		{
			var logEventData = JsonConvert.DeserializeObject<List<LogEventData>>(payload).FirstOrDefault();
            DataStore.Instance.LogEventData.Add(logEventData);
			return new ReturnValue("");
		}

		private static ReturnValue ErrorEventData(string payload)
		{
			var errorEventData = new EventData(payload);
			DataStore.Instance.ErrorEventData.Add(errorEventData.AgentRunId, errorEventData);
			return new ReturnValue("");
		}

		private static ReturnValue CustomEventData(string payload)
		{
			var customEventData = new EventData(payload);
			DataStore.Instance.CustomEventData.Add(customEventData.AgentRunId, customEventData);
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

		public static async Task<string> TryDecompress(Stream stream, string compressionsType)
		{
			var payloadMemoryStream = new MemoryStream();
			stream.CopyTo(payloadMemoryStream);

			if (compressionsType == "identity")
			{
				using (var reader = new StreamReader(payloadMemoryStream))
				{
					return await reader.ReadToEndAsync();
				}
			}

			return await Decompress(payloadMemoryStream);
		}

		public static async Task<string> Decompress(MemoryStream payloadMemoryStream)
		{
			var compressedBuffer = payloadMemoryStream.ToArray();
			var inStream = new MemoryStream(compressedBuffer);
			var outStream = new MemoryStream(compressedBuffer.Length);
			var inflateStream = new InflaterInputStream(inStream);

			inStream.Position = 0;
			byte[] resBuffer = null;
			try
			{
				var tmpBuffer = new byte[compressedBuffer.Length];
				int read = 0;

				do
				{
					read = await inflateStream.ReadAsync(tmpBuffer, 0, tmpBuffer.Length);
					if (read > 0)
					{
						await outStream.WriteAsync(tmpBuffer, 0, read);
					}

				} while (read > 0);

				resBuffer = outStream.ToArray();
			}
			finally
			{
				inflateStream.Close();
				inStream.Close();
				outStream.Close();
			}

			return Encoding.UTF8.GetString(resBuffer);
		}
	}
}
