using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    public class Report
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("action_taken")]
        public string ActionTaken { get; set; }
    }
}