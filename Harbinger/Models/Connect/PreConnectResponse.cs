using Newtonsoft.Json;

namespace Harbinger.Models.Connect
{
    internal class PreConnectResponse
    {
        [JsonProperty(PropertyName = "redirect_host")]
        public string RedirectHost { get; internal set; }
    }
}
