using Newtonsoft.Json;

namespace Harbinger.Models.Connect
{
    public class ConnectMethodRequest
    {
        [JsonProperty("pid")]
        public long Pid { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("display_host")]
        public string DisplayHost { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("app_name")]
        public string[] AppName { get; set; }

        [JsonProperty("agent_version")]
        public string AgentVersion { get; set; }

        [JsonProperty("agent_version_timestamp")]
        public long AgentVersionTimestamp { get; set; }

        [JsonProperty("security_settings")]
        public SecuritySettings SecuritySettings { get; set; }

        [JsonProperty("high_security")]
        public bool HighSecurity { get; set; }

        [JsonProperty("event_harvest_config")]
        public EventHarvestConfig EventHarvestConfig { get; set; }

        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("labels")]
        public object[] Labels { get; set; }

        [JsonProperty("settings")]
        public Settings Settings { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("utilization")]
        public Utilization Utilization { get; set; }

        [JsonProperty("environment")]
        public List<List<object>> Environment { get; set; }
    }
}
