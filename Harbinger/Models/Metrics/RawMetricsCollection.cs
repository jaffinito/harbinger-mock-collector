namespace Harbinger.Models.Metrics
{
    internal class RawMetricsCollection
    {
        public List<List<object>> MetricData { get; internal set; }

        public RawMetricsCollection()
        {
            MetricData = new List<List<object>>();
        }

        public void AddMetricData(List<object> metricPayload)
        {
            MetricData.Add(metricPayload);
        }
    }
}
