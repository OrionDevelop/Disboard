using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models.Streaming
{
    internal class WsResponse : IStreamMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("body")]
        public WsResponseObject Body { get; set; }
    }
}