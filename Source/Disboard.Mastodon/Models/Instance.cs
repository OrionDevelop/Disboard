using System.Collections.Generic;

using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
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

        // urls

        [JsonProperty("languages")]
        public List<string> Languages { get; set; }

        [JsonProperty("contact_account")]
        public Account ContactAccount { get; set; }
    }
}