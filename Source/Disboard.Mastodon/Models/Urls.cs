using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    // https://github.com/tootsuite/mastodon/blob/v2.5.0/app/serializers/rest/instance_serializer.rb#L46-L48
    public class Urls : ApiResponse
    {
        [JsonProperty("streaming_api")]
        public string StreamingApi { get; set; }
    }
}