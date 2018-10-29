using Newtonsoft.Json;

namespace Disboard.Misskey.Models.Streaming
{
    public class WsRequestObject
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}