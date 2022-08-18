using Newtonsoft.Json;

namespace Harbinger.Models.Connect
{
    public class TransactionTracer
    {
        [JsonProperty("record_sql")]
        public string RecordSql { get; set; }
    }
}
