using Newtonsoft.Json;

namespace Harbinger.Models.Connect
{
	public class EventData
	{
		[JsonProperty(PropertyName = "report_period_in_seconds")]
		public int ReportPeriodInSeconds { get; internal set; }
	}
}
