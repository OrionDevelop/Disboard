using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.PeerTube.Models
{
    public class Client : ApiResponse
    {
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }
    }
}