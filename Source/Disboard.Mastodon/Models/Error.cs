using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    public class Error
    {
        [JsonProperty("error")]
        public string ErrorDesc { get; set; }
    }
}