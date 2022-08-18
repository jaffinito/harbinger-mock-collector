using Newtonsoft.Json;

namespace Harbinger.Models.Connect
{
    internal class TransactionTracer
    {
        [JsonProperty("record_sql")]
        public string RecordSql { get; set; }
    }
}
