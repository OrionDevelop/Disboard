using System.Collections.Generic;

using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    // https://github.com/tootsuite/mastodon/blob/v2.5.0/app/serializers/rest/instance_serializer.rb
    public class Instance : ApiResponse
    {
        [JsonProperty("uri")]
        public string Url { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("urls")]
        public Urls Urls { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("languages")]
        public IEnumerable<string> Languages { get; set; }

        [JsonProperty("contact_account")]
        public Account ContactAccount { get; set; }
    }
}