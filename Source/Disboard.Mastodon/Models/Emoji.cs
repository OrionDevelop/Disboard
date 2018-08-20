using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    public class Emoji
    {
        [JsonProperty("shortcode")]
        public string Shortcode { get; set; }

        [JsonProperty("static_url")]
        public string StaticUrl { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("visible_in_picker")]
        public bool IsVisibleInPicker { get; set; }
    }
}