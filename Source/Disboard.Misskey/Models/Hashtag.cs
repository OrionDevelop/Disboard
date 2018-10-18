using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class Hashtag : ApiResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }
    }
}