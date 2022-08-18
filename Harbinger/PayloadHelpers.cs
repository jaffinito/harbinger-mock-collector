using Harbinger.Logging;
using Harbinger.Models.Connect;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System.Text;

namespace Harbinger
{
	public class PayloadHelpers
	{
		public static async Task<string> TryDecompress(Stream stream, string compressionsType)
		{
			if (compressionsType == "identity")
			{
				using (var reader = new StreamReader(stream))
				{
					return await reader.ReadToEndAsync();
				}
			}

			using (var inflaterStream = new InflaterInputStream(stream, new Inflater()))
			using (var streamReader = new StreamReader(inflaterStream, Encoding.UTF8))
			{
				return await streamReader.ReadToEndAsync();
			}
		}

		public static ConnectMethodResponse ConnectReplyMock(int agentRunId, bool staging = false)
		{
			return new ConnectMethodResponse
			{
				AgentRunId = $"{agentRunId}",
				ApdexT = 1.0,
				ApplicationId = "42977590",
				Beacon = "bam.nr-data.net",
				BrowserKey = "9df73b947f",
				BrowserMonitoringDebug = null,
				BrowserMonitoringLoader = null,
				BrowserMonitoringLoaderVersion = "1016",
				CollectAnalyticsEvents = true,
				CollectErrorReports = true,
				CollectErrors = true,
				CollectTraces = false,
				CrossProcessId = "471588#42977590",
				DataMethods = new DataMethods
				{
					AnalyticEventData = new EventData { ReportPeriodInSeconds = 60 },
					CustomEventData = new EventData { ReportPeriodInSeconds = 60 },
					ErrorEventData = new EventData { ReportPeriodInSeconds = 60 }
				},
				DataReportPeriod = 60,
				EncodingKey = "d67afc830dab717fd163bfcb0b8b88423e9a1a3b",
				EpisodeFile = "js-agent.newrelic.com/nr-100.js",
				EpisodeUrl = "https://js-agent.newrelic.com/nr-100.js",
				ErrorBeacon = "bam.nr-data.net",
				JsAgentFile = String.Empty,
				JsAgentLoader = "window.NREUM.......",
				JsAgentLoaderVersion = "nr-loader-full-476.min.js",
				Messages = new List<Message>
				{
					new Message { Level = "INFO", MessageInternal = "Reporting to: https://rpm.newrelic.com/accounts/471588/applications/42977590" }
				},
				ProductLevel = 20,
				SamplingRate = 0,
				TransactionNamingScheme = "legacy",
				TrustedAccountIds = new List<int> { 925452, 471588 },
				UrlRules = new List<UrlRule>
				{
					new UrlRule
					{
						EachSegment = false,
						EvalOrder = 1000,
						Ignore = false,
						MatchExpression = ".*\\.(ace|arj|ini|txt|udl|plist|css|gif|ico|jpe?g|js|png|swf|woff|caf|aiff|m4v|mpe?g|mp3|mp4|mov)$",
						ReplaceAll = false,
						Replacement = "/*.\\1",
						TerminateChain = false
					},
					new UrlRule
					{
						EachSegment = false,
						EvalOrder = 1001,
						Ignore = false,
						MatchExpression = "^[0-9][0-9a-f_,.-]*$",
						ReplaceAll = false,
						Replacement = "*",
						TerminateChain =false
					},
					new UrlRule
					{
						EachSegment = false,
						EvalOrder = 1002,
						Ignore = false,
						MatchExpression = "^(.*)/[0-9][0-9a-f_,-]*\\.([0-9a-z][0-9a-z]*)$",
						ReplaceAll = false,
						Replacement = "\\1/.*\\2",
						TerminateChain =false
					}
				}
			};
		}
	}
}

