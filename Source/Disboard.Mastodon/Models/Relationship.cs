using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    public class Relationship
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("following")]
        public bool IsFollowing { get; set; }

        [JsonProperty("followed_by")]
        public bool IsFollowedBy { get; set; }

        [JsonProperty("blocking")]
        public bool IsBlocking { get; set; }

        [JsonProperty("muting")]
        public bool IsMuting { get; set; }

        [JsonProperty("muting_notifications")]
        public bool IsMutingNotifications { get; set; }

        [JsonProperty("requested")]
        public bool IsRequested { get; set; }

        [JsonProperty("domain_blocking")]
        public bool IsDomainBlocking { get; set; }

        [JsonProperty("showing_reblogs")]
        public bool IsShowingReblogs { get; set; }
    }
}