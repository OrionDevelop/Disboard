using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    public class PushSubscription
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("endpoint")]
        public string Endpoint { get; set; }

        [JsonProperty("server_key")]
        public string ServerKey { get; set; }

        // map
    }
}