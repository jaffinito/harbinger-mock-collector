using Newtonsoft.Json;

namespace Harbinger.Models.Connect
{
    public class SecuritySettings
    {
        [JsonProperty("transaction_tracer")]
        public TransactionTracer TransactionTracer { get; set; }
    }
}
