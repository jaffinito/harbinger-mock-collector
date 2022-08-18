using Newtonsoft.Json;

namespace Harbinger.Data.SpanEvents
{
    public class EventHarvestData
    {
        [JsonProperty("reservoir_size")]
        public long ReservoirSize { get; set; }

        [JsonProperty("events_seen")]
        public long EventsSeen { get; set; }
    }
}
