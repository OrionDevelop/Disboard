using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    // from locales/ja-JP.yml
    public class ReactionCount : ApiResponse
    {
        [JsonProperty("like")]
        public long? Like { get; set; }

        [JsonProperty("love")]
        public long? Love { get; set; }

        [JsonProperty("laugh")]
        public long? Laugh { get; set; }

        [JsonProperty("hmm")]
        public long? Hmm { get; set; }

        [JsonProperty("surprise")]
        public long? Surprise { get; set; }

        [JsonProperty("congrats")]
        public long? Congrats { get; set; }

        [JsonProperty("angry")]
        public long? Angry { get; set; }

        [JsonProperty("confused")]
        public long? Confused { get; set; }

        [JsonProperty("rip")]
        public long? Rip { get; set; }

        [JsonProperty("pudding")]
        public long? Pudding { get; set; }
    }
}