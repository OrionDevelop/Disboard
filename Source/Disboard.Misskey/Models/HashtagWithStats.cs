using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class HashtagWithStats : ApiResponse
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("attachedLocalUsersCount")]
        public long AttachedLocalUsersCount { get; set; }

        [JsonProperty("attachedUsersCount")]
        public long AttachedUsersCount { get; set; }

        [JsonProperty("attachedRemoteUsersCount")]
        public long AttachedRemoteUsersCount { get; set; }

        [JsonProperty("mentionedLocalUsersCount")]
        public long MentionedLocalUsersCount { get; set; }

        [JsonProperty("mentionedUsersCount")]
        public long MentionedUsersCount { get; set; }

        [JsonProperty("mentionedRemoteUsersCount")]
        public long MentionedRemoteUsersCount { get; set; }
    }
}