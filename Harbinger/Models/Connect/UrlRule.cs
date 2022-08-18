using Newtonsoft.Json;

namespace Harbinger.Models.Connect
{
	public class UrlRule
	{
		[JsonProperty(PropertyName = "replacement")]
		public string Replacement { get; internal set; }

		[JsonProperty(PropertyName = "eval_order")]
		public int EvalOrder { get; internal set; }

		[JsonProperty(PropertyName = "match_expression")]
		public string MatchExpression { get; internal set; }

		[JsonProperty(PropertyName = "replace_all")]
		public bool ReplaceAll { get; internal set; }

		[JsonProperty(PropertyName = "ignore")]
		public bool Ignore { get; internal set; }

		[JsonProperty(PropertyName = "terminate_chain")]
		public bool TerminateChain { get; internal set; }

		[JsonProperty(PropertyName = "each_segment")]
		public bool EachSegment { get; internal set; }
	}
}
