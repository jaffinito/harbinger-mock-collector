using Harbinger.Data.Metrics;
using Harbinger.Data.SpanEvents;
using Harbinger.Models.Connect;

namespace Harbinger.Data
{
    public sealed class DataStore
    {
        private static readonly DataStore instance = new DataStore();

        static DataStore()
        {
        }

        private DataStore()
        {
            RawMetricData = new ();
            MetricData = new ();
            SpanEventData = new();
        }

        public static DataStore Instance => instance;

        public RawMetricData RawMetricData { get; }

        public MetricData MetricData { get; }

        public ConnectMethodRequest ConnectRequest { get; set; }

        public Dictionary<string, SpanEventData> SpanEventData { get; }
    }
}
