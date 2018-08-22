using System.Collections.Generic;

using Disboard.Mastodon.Enums;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Disboard.Mastodon.Models
{
    public class Tokens
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("scope")]
        [JsonConverter(typeof(StringEnumConverter))]
        public List<AccessScope> Scope { get; set; }

        // unused
        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }
    }
}