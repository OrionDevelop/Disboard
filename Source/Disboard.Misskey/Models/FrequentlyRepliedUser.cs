using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class FrequentlyRepliedUser : ApiResponse
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("weight")]
        public long Weight { get; set; }
    }
}