using Newtonsoft.Json;

namespace Harbinger.Models.Connect
{
	public class AgentSettings
	{
		[JsonProperty(PropertyName = "newrelic.appname")] public string AppName { get; internal set; }
		[JsonProperty(PropertyName = "newrelic.attributes.enabled")] public string AttributesEnabled { get; internal set; }
		[JsonProperty(PropertyName = "newrelic.attributes.exclude")] public string AttributesExclude { get; internal set; }
		[JsonProperty(PropertyName = "newrelic.attributes.include")] public string AttributesInclude { get; internal set; }
		[JsonProperty(PropertyName = "newrelic.browser_monitoring.attributes.enabled")] public string BrowserAttributesEnabled { get; internal set; }
		[JsonProperty(PropertyName = "newrelic.browser_monitoring.attributes.exclude")] public string BrowserAttributesExclude { get; internal set; }
		[JsonProperty(PropertyName = "newrelic.browser_monitoring.attributes.include")] public string BrowserAttributesInclude { get; internal set; }
		[JsonProperty(PropertyName = "newrelic.browser_monitoring.auto_instrument")] public string BrowserAutoInstrument { get; internal set; }
		[JsonProperty(PropertyName = "newrelic.browser_monitoring.capture_attributes")] public string BrowserCaptureAttributes { get; internal set; }
		[JsonProperty(PropertyName = "newrelic.browser_monitoring.debug")] public string BrowserDebug { get; internal set; }
		[JsonProperty(PropertyName = "newrelic.browser_monitoring.loader")] public string BrowserLoader { get; internal set; }
	}
}
