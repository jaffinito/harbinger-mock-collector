namespace Harbinger.Models.Events
{
    internal class EventHarvestData
    {
        public long ReservoirSize { get; set; }

        public long EventsSeen { get; set; }

        public EventHarvestData()
        {
            ReservoirSize = default;
            EventsSeen = default;
        }
    }
}
