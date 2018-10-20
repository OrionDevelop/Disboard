using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class Drive : ApiResponse
    {
        [JsonProperty("capacity")]
        public long Capacity { get; set; }

        [JsonProperty("usage")]
        public long Usage { get; set; }
    }
}