using System.Collections.Generic;

using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    // https://github.com/tootsuite/mastodon/blob/v2.5.0/app/serializers/rest/context_serializer.rb
    public class Context : ApiResponse
    {
        [JsonProperty("ancestors")]
        public IEnumerable<Status> Ancestors { get; set; }

        [JsonProperty("descendants")]
        public IEnumerable<Status> Descendants { get; set; }
    }
}