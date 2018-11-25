using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Disboard.Misskey.Models.Streaming
{
    public class WsRestResponseObject : WsResponseObject
    {
        [JsonProperty("res")]
        public JToken Res { get; set; }
    }
}