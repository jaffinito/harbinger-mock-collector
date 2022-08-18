using Harbinger.Models.Connect;
using Harbinger.Models.Metrics;
using Harbinger.Models.SpanEvents;

namespace Harbinger
{
    internal sealed class DataStore
    {
        private static readonly DataStore instance = new DataStore();

        static DataStore()
        {
        }

        private DataStore()
        {
            RawMetricData = new();
            MetricData = new();
            SpanEventData = new();
        }

        public static DataStore Instance => instance;

        public RawMetricData RawMetricData { get; }

        public MetricData MetricData { get; }

        public ConnectMethodRequest ConnectRequest { get; set; }

        public Dictionary<string, SpanEventData> SpanEventData { get; }
    }
}
