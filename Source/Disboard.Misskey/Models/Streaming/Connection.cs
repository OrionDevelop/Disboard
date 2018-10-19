using Newtonsoft.Json;

namespace Disboard.Misskey.Models.Streaming
{
    public class Connection : WsRequestObject
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }
    }
}