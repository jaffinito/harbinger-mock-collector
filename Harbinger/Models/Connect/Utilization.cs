using Newtonsoft.Json;

namespace Harbinger.Models.Connect
{
    internal class Utilization
    {
        [JsonProperty("metadata_version")]
        public long MetadataVersion { get; set; }

        [JsonProperty("logical_processors")]
        public long LogicalProcessors { get; set; }

        [JsonProperty("total_ram_mib")]
        public long TotalRamMib { get; set; }

        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        [JsonProperty("full_hostname")]
        public string FullHostname { get; set; }

        [JsonProperty("ip_address")]
        public string[] IpAddress { get; set; }
    }
}
