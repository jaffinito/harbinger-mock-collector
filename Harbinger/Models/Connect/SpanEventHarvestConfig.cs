using Newtonsoft.Json;

namespace Harbinger.Models.Connect
{
    public class SpanEventHarvestConfig
    {
        [JsonProperty("harvest_limit")]
        public int HarvestLimit { get; set; }

        [JsonProperty("report_period_ms")]
        public int ReportPeriodMilliseconds { get; set; }
    }
}
