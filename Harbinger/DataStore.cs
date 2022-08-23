using Harbinger.Models.Connect;
using Harbinger.Models.Metrics;
using Harbinger.Models;

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
            ErrorTraceData = new();
            TransactionSampleData = new();
        }

        public static DataStore Instance => instance;

        public RawMetricsCollection RawMetricData { get; }

        public MetricsCollection MetricData { get; }

        public ConnectMethodRequest ConnectRequest { get; set; }

        public DataCollection SpanEventData { get; }

        public DataCollection TransactionEventData { get; }

        public DataCollection ErrorEventData { get; }

        public DataCollection CustomEventData { get; }

        public DataCollection ErrorTraceData { get; }

        public DataCollection LogEventData { get; }

        public DataCollection TransactionSampleData { get; }
    }
}