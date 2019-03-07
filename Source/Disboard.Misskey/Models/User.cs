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
        public Color? AvatarColor { get; set; }

        [JsonProperty("avatarId")]
        public string AvatarId { get; set; }

        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }

        [JsonProperty("bannerColor")]
        [JsonConverter(typeof(RgbArrayToColorConverter))]
        public Color? BannerColor { get; set; }

        [JsonProperty("bannerId")]
        public string BannerId { get; set; }

        [JsonProperty("bannerUrl")]
        public string BannerUrl { get; set; }

        [JsonProperty("carefulBot")]
        public bool IsCarefulBot { get; set; }

        [JsonProperty("createdAt")]
        [JsonConverter(typeof(UnionToDateTimeConverter))]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("driveCapacity")]
        public long? DriveCapacity { get; set; }

        [JsonProperty("emojis")]
        public List<Emoji> Emojis { get; set; }

        [JsonProperty("endpoints")]
        public Endpoints Endpoints { get; set; }

        [JsonProperty("featured")]
        public string Featured { get; set; }

        [JsonProperty("followersCount")]
        public long FollowersCount { get; set; }

        [JsonProperty("followersYouKnowCount")]
        public long? FollowersYouKnowCount { get; set; }

        [JsonProperty("followingCount")]
        public long FollowingCount { get; set; }

        [JsonProperty("followingYouKnowCount")]
        public long? FollowingYouKnowCount { get; set; }

        [JsonProperty("hasPendingFollowRequestFromYou")]
        public bool? HasPendingFollowRequestFromYou { get; set; }

        [JsonProperty("hasPendingFollowRequestToYou")]
        public bool? HasPendingFollowRequestToYou { get; set; }

        [JsonProperty("hasUnreadMentions")]
        public bool? HasUnreadMentions { get; set; }

        [JsonProperty("hasUnreadMessage")]
        public bool? HasUnreadMessage { get; set; }

        [JsonProperty("hasUnreadNotification")]
        public bool? HasUnreadNotification { get; set; }

        [JsonProperty("hasUnreadSpecifiedNotes")]
        public bool? HasUnreadSpecifiedNotes { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("hostLower")]
        public string HostLower { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("Inbox")]
        public string Inbox { get; set; }

        [JsonProperty("isAdmin")]
        public bool? IsAdmin { get; set; }

        [JsonProperty("isBlocked")]
        public bool? IsBlocked { get; set; }

        [JsonProperty("isBlocking")]
        public bool? IsBlocking { get; set; }

        [JsonProperty("isBot")]
        public bool? IsBot { get; set; }

        [JsonProperty("isCat")]
        public bool? IsCat { get; set; }

        [JsonProperty("isFollowed")]
        public bool? IsFollowed { get; set; }

        [JsonProperty("isFollowing")]
        public bool? IsFollowing { get; set; }

        [JsonProperty("isMuted")]
        public bool? IsMuted { get; set; }

        [JsonProperty("isStalking")]
        public bool? IsStalking { get; set; }

        [JsonProperty("isPro")]
        public bool? IsPro { get; set; }

        [JsonProperty("isVerified")]
        public bool? IsVerified { get; set; }

        [JsonProperty("isLocked")]
        public bool? IsLocked { get; set; }

        [JsonProperty("isSuspended")]
        public bool IsSuspended { get; set; }

        [JsonProperty("lastUsedAt")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? LastUsedAt { get; set; }

        [JsonProperty("links")]
        public ApiResponse Links { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("notesCount")]
        public long NotesCount { get; set; }

        [JsonProperty("pendingReceivedFollowRequestsCount")]
        public long PendingReceivedFollowRequestsCount { get; set; }

        [JsonProperty("pinnedNotes")]
        public IEnumerable<Note> PinnedNotes { get; set; }

        [JsonProperty("pinnedNoteIds")]
        public IEnumerable<string> PinnedNoteIds { get; set; }

        [JsonProperty("profile")]
        public Profile Profile { get; set; }

        [JsonProperty("sharedInbox")]
        public string SharedInbox { get; set; }

        [JsonProperty("twitter")]
        public Twitter Twitter { get; set; }

        [JsonProperty("twoFactorEnabled")]
        public bool? IsTwoFactorEnabled { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("updatedAt")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("usernameLower")]
        public string UsernameLower { get; set; }

        [JsonProperty("wallpaperColor")]
        [JsonConverter(typeof(RgbArrayToColorConverter))]
        public Color? WallpaperColor { get; set; }

        [JsonProperty("wallpaperId")]
        public string WallpaperId { get; set; }

        [JsonProperty("wallpaperUrl")]
        public string WallpaperUrl { get; set; }
    }
}