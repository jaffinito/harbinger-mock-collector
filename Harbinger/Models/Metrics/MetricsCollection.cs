using Newtonsoft.Json.Linq;

namespace Harbinger.Models.Metrics
{
    internal class MetricsCollection
    {
        public readonly Dictionary<string, List<ScopedMetric>> ScopedMetrics; // scope, (name, numbers)
        public readonly Dictionary<string, Timeslice> UnscopedMetrics; // name, number

        public MetricsCollection()
        {
            ScopedMetrics = new Dictionary<string, List<ScopedMetric>>();
            UnscopedMetrics = new Dictionary<string, Timeslice>();
        }

        public void Add(List<object> metricDataObject)
        {
            // Get metrics array from payload
            var metricsArray = (JArray)metricDataObject[3];
            AddGeneratedUnscopedMetric("Agent/MetricsReported/count", metricsArray.Count);

            // work on each metric package array in metricsArray
            foreach (var metricPackage in metricsArray)
            {
                // Two parts ORDERED, one is an object (name, scope), other is array of nums (data)
                var metricParts = metricPackage.Children().ToList<object>();

                // gets name string from object
                var name = ((JToken)metricParts[0]).Value<string>("name");

                // gets scope from object or sets to empty
                var scope = ((JToken)metricParts[0]).Value<string>("scope") ?? string.Empty;

                // gets numbers array
                var numbers = (JArray)metricParts[1];

                if (string.IsNullOrWhiteSpace(scope))
                {
                    // unscoped
                    BuildUnscopeMetric(name, numbers);
                }
                else
                {
                    //scoped
                    BuildScopedMetric(name, scope, numbers);
                }
            }
        }

        public void AddGeneratedUnscopedMetric(string name, int count = 1)
        {
            var numbers = new object[] { count, 0.0, 0.0, 0.0, 0.0, 0.0 };
            var jArray = new JArray(numbers.Select(i => JToken.FromObject(i)));
            BuildUnscopeMetric(name, jArray);
        }

        private void BuildUnscopeMetric(string name, JArray numbers)
        {
            // unscoped
            Timeslice timeSlice;
            if (UnscopedMetrics.TryGetValue(name, out timeSlice))
            {
                timeSlice.UpdateTimeSlice((int)numbers[0], (double)numbers[1], (double)numbers[2], (double)numbers[3], (double)numbers[4], (double)numbers[5]);
            }
            else
            {
                timeSlice = new Timeslice((int)numbers[0], (double)numbers[1], (double)numbers[2], (double)numbers[3], (double)numbers[4], (double)numbers[5]);
                UnscopedMetrics.Add(name, timeSlice);
            }
        }

        private void BuildScopedMetric(string name, string scope, JArray numbers)
        {
            //scoped
            List<ScopedMetric> scopedMetrics;
            if (ScopedMetrics.TryGetValue(scope, out scopedMetrics))
            {
                var scopedMetricExistingScope = scopedMetrics.FirstOrDefault(s => s.Name == name);

                if (scopedMetricExistingScope == null)
                {
                    scopedMetrics.Add(new ScopedMetric(name,
                        new Timeslice((int)numbers[0], (double)numbers[1], (double)numbers[2],
                            (double)numbers[3], (double)numbers[4], (double)numbers[5])));
                }
                else
                {
                    scopedMetricExistingScope.UpdateTimeSlice((int)numbers[0], (double)numbers[1], (double)numbers[2],
                        (double)numbers[3], (double)numbers[4], (double)numbers[5]);
                }
            }
            else
            {
                var scopedMetricNewScope = new ScopedMetric(name,
                    new Timeslice((int)numbers[0], (double)numbers[1], (double)numbers[2],
                        (double)numbers[3], (double)numbers[4], (double)numbers[5]));
                ScopedMetrics.Add(scope, new List<ScopedMetric>() { scopedMetricNewScope });
            }
        }
    }
}
