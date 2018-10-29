using System;

using Disboard.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Disboard.Misskey.Models
{
    public class Notification : ApiResponse
    {
        [JsonProperty("createdAt")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("isRead")]
        public bool IsRead { get; set; }

        [JsonProperty("note")]
        public Note Note { get; set; }

        [JsonProperty("noteId")]
        public string NoteId { get; set; }

        [JsonProperty("reaction")]
        public string Reaction { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}