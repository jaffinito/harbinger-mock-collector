using Newtonsoft.Json;

namespace Harbinger.Models.Events
{
    public class LogEvent
    {
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("span.id")]
        public string SpanId { get; set; }

        [JsonProperty("trace.id")]
        public string TraceId { get; set; }
    }
}
