using System;

using Disboard.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Disboard.Mastodon.Models
{
    // https://github.com/tootsuite/mastodon/blob/master/app/serializers/rest/account_serializer.rb#L13-L19
    public class Field : ApiResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("verified_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? VerifiedAt { get; set; }
    }
}