using System.Collections.Generic;

using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    // https://github.com/tootsuite/mastodon/blob/v2.5.0/app/serializers/rest/credential_account_serializer.rb#L6-L16
    public class Source
    {
        [JsonProperty("privacy")]
        public string Privacy { get; set; }

        [JsonProperty("sensitive")]
        public bool IsSensitive { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("fields")]
        public List<Field> Fields { get; set; }
    }
}