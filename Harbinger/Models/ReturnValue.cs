using Newtonsoft.Json;

namespace Harbinger.Models
{
	internal class ReturnValue
	{
		[JsonProperty(PropertyName = "return_value")]
		public object Value { get; set; }

		public ReturnValue(object value)
		{
			Value = value;
		}
	}
}
