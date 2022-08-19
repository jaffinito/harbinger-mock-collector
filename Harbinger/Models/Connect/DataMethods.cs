using Newtonsoft.Json;

namespace Harbinger.Models.Connect
{
	public class DataMethods
	{
		[JsonProperty(PropertyName = "error_event_data")]
		public EventDataConfiguration ErrorEventData { get; internal set; }

		[JsonProperty(PropertyName = "analytic_event_data")]
		public EventDataConfiguration AnalyticEventData { get; internal set; }

		[JsonProperty(PropertyName = "custom_event_data")]
		public EventDataConfiguration CustomEventData { get; internal set; }

		[JsonProperty(PropertyName = "span_event_data")]
		public EventDataConfiguration SpanEventData { get; internal set; }
	}
}
