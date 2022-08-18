using Newtonsoft.Json;

namespace Harbinger.Models.Connect
{
	public class Message
	{
		[JsonProperty(PropertyName = "level")]
		public string Level { get; internal set; }

		[JsonProperty(PropertyName = "message")]
		public string MessageInternal { get; internal set; }
	}
}
