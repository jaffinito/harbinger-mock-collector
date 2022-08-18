using Harbinger.Models.Metrics;

namespace Harbinger.Data
{
    public static partial class Api
    {
        public static bool UnscopedMetricExists(string metric)
        {
            return DataStore.Instance.MetricData.UnscopedMetrics.ContainsKey(metric);
        }

        public static bool ScopedMetricExists(string metric, string scope)
        {
            List<ScopedMetric> scopedMetrics;
            if (!DataStore.Instance.MetricData.ScopedMetrics.TryGetValue(scope, out scopedMetrics)) return false;

            var scopedMetric = scopedMetrics.FirstOrDefault(s => s.Name == metric);
            return scopedMetric != null;
        }
    }
}
