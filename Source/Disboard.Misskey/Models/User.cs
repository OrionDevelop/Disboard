using System;
using System.Collections.Generic;
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

        [JsonProperty("bannerColor")]
        [JsonConverter(typeof(RgbArrayToColorConverter))]
        public Color BannerColor { get; set; }

        [JsonProperty("bannerId")]
        public string BannerId { get; set; }

        [JsonProperty("bannerUrl")]
        public string BannerUrl { get; set; }

        [JsonProperty("createdAt")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("driveCapacity")]
        public long DriveCapacity { get; set; }

        [JsonProperty("followersCount")]
        public long FollowersCount { get; set; }

        [JsonProperty("followingCount")]
        public long FollowingCount { get; set; }

        [JsonProperty("hasUnreadNotification")]
        public bool? HasUnreadNotification { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("isBot")]
        public bool IsBot { get; set; }

        [JsonProperty("isCat")]
        public bool IsCat { get; set; }

        [JsonProperty("isLocked")]
        public bool IsLocked { get; set; }

        [JsonProperty("isPro")]
        public bool? IsPro { get; set; }

        [JsonProperty("lastUsedAt")]
        public DateTime LastUsedAt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("notesCount")]
        public long NotesCount { get; set; }

        [JsonProperty("pinnedNoteIds")]
        public List<string> PinnedNoteIds { get; set; }

        [JsonProperty("pendingReceivedFollowRequestsCount")]
        public int? PendingReceivedFollowRequestsCount { get; set; }

        [JsonProperty("profile")]
        public Profile Profile { get; set; }

        [JsonProperty("twitter")]
        public object Twitter { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("wallpaperColor")]
        [JsonConverter(typeof(RgbArrayToColorConverter))]
        public Color WallpaperColor { get; set; }

        [JsonProperty("wallpaperId")]
        public string WallpaperId { get; set; }

        [JsonProperty("wallpaperUrl")]
        public string WallpaperUrl { get; set; }
    }
}