using Harbinger.Models.Connect;
using Harbinger.Models.Metrics;
using Harbinger.Models.Events;

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
            TransactionEventData = new();
            LogEventData = new();
            ErrorEventData = new();
            CustomEventData = new();
        }

        public static DataStore Instance => instance;

        public RawMetricsCollection RawMetricData { get; }

        public MetricsCollection MetricData { get; }

        public ConnectMethodRequest ConnectRequest { get; set; }

        public Dictionary<string, EventData> SpanEventData { get; }

        public Dictionary<string, EventData> TransactionEventData { get; }

        public Dictionary<string, EventData> ErrorEventData { get; }

        public Dictionary<string, EventData> CustomEventData { get; }

        public List<LogEventData> LogEventData { get; }
    }
}