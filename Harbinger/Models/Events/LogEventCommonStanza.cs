using Newtonsoft.Json;

namespace Harbinger.Models.Events
{
    public class LogEventCommonStanza
    {
        [JsonProperty("attributes")]
        public LogEventAttributeStanza Attributes { get; set; }
    }
}
