namespace Harbinger.Data.Metrics
{
    public class RawMetricData
    {
        public List<List<object>> MetricData { get; internal set; }

        public RawMetricData()
        {
            MetricData = new List<List<object>>();
        }

        public void AddMetricData(List<object> metricPayload)
        {
            MetricData.Add(metricPayload);
        }
    }
}
