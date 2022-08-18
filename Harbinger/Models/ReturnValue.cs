using Newtonsoft.Json;

namespace Harbinger.Models
{
	internal class ReturnValue
	{
		[JsonProperty(PropertyName = "return_value")]
		public object Value { get; internal set; }

		public ReturnValue(object value)
		{
			Value = value;
		}
	}
}
