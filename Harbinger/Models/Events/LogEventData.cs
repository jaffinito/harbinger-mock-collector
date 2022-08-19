using Newtonsoft.Json;

namespace Harbinger.Models.Events
{
    public class LogEventData
    {
        [JsonProperty("common")]
        public LogEventCommonStanza Common { get; set; }

        [JsonProperty("logs")]
        public List<LogEvent> LogEvents { get; set; }
    }
}
