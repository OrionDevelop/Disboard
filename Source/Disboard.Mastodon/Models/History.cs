using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    public class History : ApiResponse
    {
        [JsonProperty("day")]
        public long Day { get; set; }

        [JsonProperty("uses")]
        public long Uses { get; set; }

        [JsonProperty("accounts")]
        public long Accounts { get; set; }
    }
}