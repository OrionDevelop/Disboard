using System.Collections.Generic;

using Disboard.Converters;
using Disboard.Mastodon.Enums;

using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    public class Tokens
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("scope")]
        [JsonConverter(typeof(StringFlagConverter))]
        public List<AccessScope> Scope { get; set; }

        // unused
        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }
    }
}