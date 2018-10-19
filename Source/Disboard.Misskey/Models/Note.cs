using System;
using System.Collections.Generic;

using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class Note : ApiResponse
    {
        [JsonProperty("appId")]
        public string AppId { get; set; }

        [JsonProperty("app")]
        public object App { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("cw")]
        public string Cw { get; set; }

        [JsonProperty("deletedAt")]
        public DateTime DeletedAt { get; set; }

        [JsonProperty("fileIds")]
        public List<string> FileIds { get; set; }

        [JsonProperty("geo")]
        public Geo Geo { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("mediaIds")]
        public List<string> MediaIds { get; set; }

        [JsonProperty("mentions")]
        public List<string> Mentions { get; set; }

        [JsonProperty("mentionedRemoteUsers")]
        public List<User> MentionedRemoteUsers { get; set; }

        // always null
        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("reactionCounts")]
        public string ReactionCounts { get; set; }

        [JsonProperty("repliesCount")]
        public string ReplyCount { get; set; }

        [JsonProperty("reply")]
        public Note Reply { get; set; }

        [JsonProperty("replyId")]
        public string ReplyId { get; set; }

        [JsonProperty("renote")]
        public Note Renote { get; set; }

        [JsonProperty("renoteCount")]
        public int RenoteCount { get; set; }

        [JsonProperty("renoteId")]
        public string RenoteId { get; set; }

        [JsonProperty("poll")]
        public Poll Poll { get; set; }

        // always null
        [JsonProperty("prev")]
        public string Prev { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("viaMobile")]
        public bool ViaMobile { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        [JsonProperty("visibleUserIds")]
        public List<string> VisibleUserIds { get; set; }
    }
}