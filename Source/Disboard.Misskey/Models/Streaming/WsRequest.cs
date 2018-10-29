using Newtonsoft.Json;

namespace Disboard.Misskey.Models.Streaming
{
    public class WsRequest
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("body")]
        public WsRequestObject Body { get; set; }
    }
}