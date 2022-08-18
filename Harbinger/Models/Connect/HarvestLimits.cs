using Newtonsoft.Json;

namespace Harbinger.Models.Connect
{
    public class HarvestLimits
    {
        [JsonProperty("analytic_event_data")]
        public long AnalyticEventData { get; set; }

        [JsonProperty("custom_event_data")]
        public long CustomEventData { get; set; }

        [JsonProperty("error_event_data")]
        public long ErrorEventData { get; set; }

        [JsonProperty("span_event_data")]
        public long SpanEventData { get; set; }

        [JsonProperty("log_event_data")]
        public long LogEventData { get; set; }
    }
}
