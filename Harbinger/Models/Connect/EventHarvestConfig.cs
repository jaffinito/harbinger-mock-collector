using Newtonsoft.Json;

namespace Harbinger.Models.Connect
{
    public class EventHarvestConfig
    {
        [JsonProperty("harvest_limits")]
        public HarvestLimits HarvestLimits { get; set; }
    }
}
