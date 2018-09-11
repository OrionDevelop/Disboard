using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    // https://github.com/tootsuite/mastodon/blob/v2.5.0/app/serializers/rest/custom_emoji_serializer.rb
    public class Emoji : ApiResponse
    {
        [JsonProperty("shortcode")]
        public string Shortcode { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("static_url")]
        public string StaticUrl { get; set; }

        [JsonProperty("visible_in_picker")]
        public bool IsVisibleInPicker { get; set; }
    }
}