using Newtonsoft.Json;

namespace Harbinger.Models.Connect
{
    public class PreConnectResponse
    {
        [JsonProperty(PropertyName = "redirect_host")]
        public string RedirectHost { get; internal set; }
    }
}
