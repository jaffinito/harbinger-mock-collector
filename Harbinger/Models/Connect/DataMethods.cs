using Newtonsoft.Json;

namespace Harbinger.Models.Connect
{
	public class DataMethods
	{
		[JsonProperty(PropertyName = "error_event_data")]
		public EventData ErrorEventData { get; internal set; }

		[JsonProperty(PropertyName = "analytic_event_data")]
		public EventData AnalyticEventData { get; internal set; }

		[JsonProperty(PropertyName = "custom_event_data")]
		public EventData CustomEventData { get; internal set; }
	}
}
