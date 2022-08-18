using Newtonsoft.Json;

namespace Harbinger.Models.Connect
{
    internal class PreConnectRequest
    {
        [JsonProperty(PropertyName = "high_security")]
        public bool HighSecurity { get; internal set; }
    }
}
