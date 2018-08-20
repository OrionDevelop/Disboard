using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    public class Mention
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("acct")]
        public string Acct { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
    }
}