using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    // https://github.com/tootsuite/mastodon/blob/v2.5.0/app/serializers/rest/instance_serializer.rb#L38-L44
    public class Stats : ApiResponse
    {
        [JsonProperty("user_count")]
        public long UserCount { get; set; }

        [JsonProperty("status_count")]
        public long StatusCount { get; set; }

        [JsonProperty("domain_count")]
        public long DomainCount { get; set; }
    }
}