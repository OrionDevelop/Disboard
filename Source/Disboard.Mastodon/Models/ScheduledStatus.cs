using System;
using System.Collections.Generic;

using Disboard.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Disboard.Mastodon.Models
{
    public class ScheduledStatus : ApiResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("scheduled_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime ScheduledAt { get; set; }

        [JsonProperty("params")]
        public StatusParams Params { get; set; }

        [JsonProperty("media_attachments")]
        public List<Attachment> MediaAttachments { get; set; }
    }
}