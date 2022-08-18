using Newtonsoft.Json;

namespace Harbinger.Models.Connect
{
    internal class SecuritySettings
    {
        [JsonProperty("transaction_tracer")]
        public TransactionTracer TransactionTracer { get; set; }
    }
}
