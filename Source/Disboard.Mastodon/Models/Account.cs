using System;
using System.Collections.Generic;

using Disboard.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Disboard.Mastodon.Models
{
    // https://github.com/tootsuite/mastodon/blob/v2.5.0/app/serializers/rest/account_serializer.rb
    public class Account : ApiResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("acct")]
        public string Acct { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("locked")]
        public bool IsLocked { get; set; }

        [JsonProperty("bot")]
        public bool? IsBot { get; set; }

        [JsonProperty("created_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("avatar_static")]
        public string AvatarStatic { get; set; }

        [JsonProperty("header")]
        public string Header { get; set; }

        [JsonProperty("header_static")]
        public string HeaderStatic { get; set; }

        [JsonProperty("followers_count")]
        public long FollowersCount { get; set; }

        [JsonProperty("following_count")]
        public long FollowingCount { get; set; }

        [JsonProperty("statuses_count")]
        public long StatusesCount { get; set; }

        [JsonProperty("moved")]
        public Account MovedTo { get; set; }

        [JsonProperty("emojis")]
        public IEnumerable<Emoji> Emojis { get; set; }

        [JsonProperty("fields")]
        public IEnumerable<Field> Fields { get; set; }
    }
}