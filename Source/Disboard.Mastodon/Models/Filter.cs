using System;
using System.Collections.Generic;

using Disboard.Mastodon.Enums;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Disboard.Mastodon.Models
{
    public class Filter
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("phrase")]
        public string Phrase { get; set; }

        [JsonProperty("context")]
        [JsonConverter(typeof(StringEnumConverter))]
        public IEnumerable<FilterContext> Context { get; set; }

        [JsonProperty("expires_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime ExpiresAt { get; set; }

        [JsonProperty("irreversible")]
        public bool IsIrreversible { get; set; }

        [JsonProperty("whole_word")]
        public bool IsWholeWord { get; set; }
    }
}