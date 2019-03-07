using System;
using System.Collections.Generic;

using Disboard.Mastodon.Enums;
using Disboard.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Disboard.Mastodon.Models
{
    public class StatusParams : ApiResponse
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("in_reply_to_id")]
        public string InReplyToId { get; set; }

        [JsonProperty("media_ids")]
        public List<string> MediaIds { get; set; }

        [JsonProperty("sensitive")]
        public bool? IsSensitive { get; set; }

        [JsonProperty("spoiler_text")]
        public string SpoilerText { get; set; }

        [JsonProperty("visibility")]
        [JsonConverter(typeof(StringEnumConverter))]
        public VisibilityType? Visibility { get; set; }

        [JsonProperty("scheduled_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? ScheduledAt { get; set; }

        [JsonProperty("application_id")]
        public string ApplicationId { get; set; }

        [JsonProperty("idempotency")]
        public string Idempotency { get; set; }
    }
}