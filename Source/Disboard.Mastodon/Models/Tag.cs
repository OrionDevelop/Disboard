using System.Collections.Generic;

using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    // https://github.com/tootsuite/mastodon/blob/v2.5.0/app/serializers/rest/status_serializer.rb#L118-L126
    // https://github.com/tootsuite/mastodon/blob/v2.5.0/app/serializers/rest/tag_serializer.rb
    public class Tag : ApiResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("history")]
        public IEnumerable<History> History { get; set; }
    }
}