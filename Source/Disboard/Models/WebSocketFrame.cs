using Newtonsoft.Json;

namespace Disboard.Models
{
    public class WebSocketFrame : ApiResponse
    {
        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("payload")]
        public string Payload { get; set; }
    }
}