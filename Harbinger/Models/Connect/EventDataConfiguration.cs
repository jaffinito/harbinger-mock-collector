using Newtonsoft.Json;

namespace Harbinger.Models.Connect
{
	public class EventDataConfiguration
	{
		[JsonProperty(PropertyName = "report_period_in_seconds")]
		public int ReportPeriodInSeconds { get; internal set; }

		[JsonProperty(PropertyName = "max_samples_stored")]
		public int MaxSampleStored { get; internal set; }
	}
}
