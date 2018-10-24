using System.Collections.Generic;

using Disboard.Converters;
using Disboard.Mastodon.Enums;
using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    public class Tokens : ApiResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("scope")]
        [JsonConverter(typeof(StringFlagConverter))]
        public IEnumerable<AccessScope> Scope { get; set; }

        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }
    }
}