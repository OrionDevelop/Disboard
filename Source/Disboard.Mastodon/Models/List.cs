using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    public class List
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}