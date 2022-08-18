using Newtonsoft.Json;

namespace Harbinger.Models.SpanEvents
{
    internal class EventHarvestData
    {
        [JsonProperty("reservoir_size")]
        public long ReservoirSize { get; set; }

        [JsonProperty("events_seen")]
        public long EventsSeen { get; set; }
    }
}
