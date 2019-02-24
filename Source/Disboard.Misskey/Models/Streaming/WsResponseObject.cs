using Disboard.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Disboard.Misskey.Models.Streaming
{
    public class WsResponseObject : ApiResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("body")]
        public JToken RawBody { get; set; }

        [JsonIgnore]
        public IStreamMessage Decoded { get; set; }
    }
}