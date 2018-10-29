using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class UserRecommendation : ApiResponse
    {
        [JsonProperty("external")]
        public bool External { get; set; }

        [JsonProperty("engine")]
        public string Engine { get; set; }

        [JsonProperty("timeout")]
        public int Timeout { get; set; }
    }
}