using Newtonsoft.Json;

namespace Harbinger.Models.Connect
{
	internal class ConnectMethodResponse
	{
		[JsonProperty(PropertyName = "agent_run_id")]
		public string AgentRunId { get; internal set; }

		[JsonProperty(PropertyName = "apdex_t")]
		public double ApdexT { get; internal set; }

		[JsonProperty(PropertyName = "application_id")]
		public string ApplicationId { get; internal set; }

		[JsonProperty(PropertyName = "beacon")]
		public string Beacon { get; internal set; }

		[JsonProperty(PropertyName = "browser_key")]
		public string BrowserKey { get; internal set; }

		[JsonProperty(PropertyName = "browser_monitoring.debug")]
		public string BrowserMonitoringDebug { get; internal set; }

		[JsonProperty(PropertyName = "browser_monitoring.loader")]
		public object BrowserMonitoringLoader { get; internal set; }

		[JsonProperty(PropertyName = "browser_monitoring.loader_version")]
		public string BrowserMonitoringLoaderVersion { get; internal set; }

		[JsonProperty(PropertyName = "collect_analytics_events")]
		public bool CollectAnalyticsEvents { get; internal set; }

		[JsonProperty(PropertyName = "collect_error_events")]
		public bool CollectErrorReports { get; internal set; }

		[JsonProperty(PropertyName = "collect_errors")]
		public bool CollectErrors { get; internal set; }

		[JsonProperty(PropertyName = "collect_traces")]
		public bool CollectTraces { get; internal set; }

		[JsonProperty(PropertyName = "cross_process_id")]
		public string CrossProcessId { get; internal set; }

		[JsonProperty(PropertyName = "data_methods")]
		public DataMethods DataMethods { get; internal set; }

		[JsonProperty(PropertyName = "data_report_period")]
		public int DataReportPeriod { get; internal set; }

		[JsonProperty(PropertyName = "encoding_key")]
		public string EncodingKey { get; internal set; }

		[JsonProperty(PropertyName = "episodes_file")]
		public string EpisodeFile { get; internal set; }

		[JsonProperty(PropertyName = "episodes_url")]
		public string EpisodeUrl { get; internal set; }

		[JsonProperty(PropertyName = "error_beacon")]
		public string ErrorBeacon { get; internal set; }

		[JsonProperty(PropertyName = "js_agent_file")]
		public string JsAgentFile { get; internal set; }

		[JsonProperty(PropertyName = "js_agent_loader")]
		public string JsAgentLoader { get; internal set; }

		[JsonProperty(PropertyName = "js_agent_loader_version")]
		public string JsAgentLoaderVersion { get; internal set; }

		[JsonProperty(PropertyName = "messages")]
		public List<Message> Messages { get; internal set; }

		[JsonProperty(PropertyName = "product_level")]
		public int ProductLevel { get; internal set; }

		[JsonProperty(PropertyName = "sampling_rate")]
		public int SamplingRate { get; internal set; }

		[JsonProperty(PropertyName = "transaction_naming_scheme")]
		public string TransactionNamingScheme { get; internal set; }

		[JsonProperty(PropertyName = "trusted_account_ids")]
		public List<int> TrustedAccountIds { get; internal set; }

		[JsonProperty(PropertyName = "url_rules")]
		public List<UrlRule> UrlRules { get; internal set; }
	}
}
