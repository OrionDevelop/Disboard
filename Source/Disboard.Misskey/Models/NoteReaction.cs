using System;

using Disboard.Misskey.Enums;
using Disboard.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Disboard.Misskey.Models
{
    public class NoteReaction : ApiResponse
    {
        [JsonProperty("createdAt")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("noteId")]
        public string NoteId { get; set; }

        [JsonProperty("reaction")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Reaction ReactionType { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}