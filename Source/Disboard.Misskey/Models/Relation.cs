using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class Relation : ApiResponse
    {
        [JsonProperty("isBlocked")]
        public bool IsBlocked { get; set; }

        [JsonProperty("isBlocking")]
        public bool IsBlocking { get; set; }

        [JsonProperty("isFollowing")]
        public bool IsFollowing { get; set; }

        [JsonProperty("isFollowed")]
        public bool IsFollowed { get; set; }

        [JsonProperty("isMuted")]
        public bool IsMuted { get; set; }

        [JsonProperty("isStalking")]
        public bool? IsStalking { get; set; }

        [JsonProperty("hasPendingFollowRequestFromYou")]
        public bool HasPendingFollowRequestFromYou { get; set; }

        [JsonProperty("hasPendingFollowRequestToYou")]
        public bool HasPendingFollowRequestToYou { get; set; }
    }
}