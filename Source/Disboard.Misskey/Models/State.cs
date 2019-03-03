using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class State : ApiResponse
    {
        [JsonProperty("isFavorited")]
        public bool IsFavorited { get; set; }

        [JsonProperty("isWatching")]
        public bool IsWatching { get; set; }
    }
}