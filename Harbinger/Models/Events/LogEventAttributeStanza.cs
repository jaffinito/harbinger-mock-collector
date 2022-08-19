using Newtonsoft.Json;

namespace Harbinger.Models.Events
{
    public class LogEventAttributeStanza
    {
        [JsonProperty("entity.name")]
        public string EntityName { get; set; }

        [JsonProperty("entity.guid")]
        public object EntityGuid { get; set; }

        [JsonProperty("hostname")]
        public string Hostname { get; set; }
    }
}
