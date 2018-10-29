using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class ChartNetworkData : ApiResponse
    {
        [JsonProperty("requests")]
        public long Requests { get; set; }

        [JsonProperty("totalTime")]
        public long TotalTime { get; set; }

        [JsonProperty("incomingBytes")]
        public long IncomingBytes { get; set; }

        [JsonProperty("outgoingBytes")]
        public long OutgoingBytes { get; set; }
    }
}