using System;
using System.Drawing;

using Disboard.Converters;
using Disboard.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Disboard.Misskey.Models
{
    public class User : ApiResponse
    {
        [JsonProperty("avatarColor")]
        [JsonConverter(typeof(RgbArrayToColorConverter))]
        public Color AvatarColor { get; set; }

        [JsonProperty("avatarId")]
        public string AvatarId { get; set; }

        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }

        [JsonProperty("bannerId")]
        public string BannerId { get; set; }

        [JsonProperty("hasUnreadNotification")]
        public bool? HasUnreadNotification { get; set; }

        [JsonProperty("isCat")]
        public bool IsCat { get; set; }

        [JsonProperty("createdAt")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("followersCount")]
        public long FollowersCount { get; set; }

        [JsonProperty("followingCount")]
        public long FollowingCount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("notesCount")]
        public long NotesCount { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("profile")]
        public Profile Profile { get; set; }

        [JsonProperty("lastUsedAt")]
        public DateTime LastUsedAt { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}