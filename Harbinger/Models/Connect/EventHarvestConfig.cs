using Newtonsoft.Json;

namespace Harbinger.Models.Connect
{
    internal class EventHarvestConfig
    {
        [JsonProperty("harvest_limits")]
        public HarvestLimits HarvestLimits { get; set; }
    }
}
