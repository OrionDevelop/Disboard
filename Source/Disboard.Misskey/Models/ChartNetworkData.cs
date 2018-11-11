using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class ChartNetworkData<T> : ApiResponse
    {
        [JsonProperty("requests")]
        public T Requests { get; set; }

        [JsonProperty("totalTime")]
        public T TotalTime { get; set; }

        [JsonProperty("incomingBytes")]
        public T IncomingBytes { get; set; }

        [JsonProperty("incomingRequests")]
        public T IncomingRequests { get; set; }

        [JsonProperty("outgoingBytes")]
        public T OutgoingBytes { get; set; }

        [JsonProperty("outgoingRequests")]
        public T OutgoingRequests { get; set; }
    }
}