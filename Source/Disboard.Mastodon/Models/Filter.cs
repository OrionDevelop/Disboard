using System;
using System.Collections.Generic;

using Disboard.Mastodon.Enums;
using Disboard.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Disboard.Mastodon.Models
{
    // https://github.com/tootsuite/mastodon/blob/v2.5.0/app/serializers/rest/filter_serializer.rb
    public class Filter : ApiResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("phrase")]
        public string Phrase { get; set; }

        [JsonProperty("context", ItemConverterType = typeof(StringEnumConverter))]
        public IEnumerable<FilterContext> Context { get; set; }

        [JsonProperty("whole_word")]
        public bool IsWholeWord { get; set; }

        [JsonProperty("expires_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? ExpiresAt { get; set; }

        [JsonProperty("irreversible")]
        public bool IsIrreversible { get; set; }
    }
}