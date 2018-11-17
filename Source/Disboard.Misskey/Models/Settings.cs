using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class Settings : ApiResponse
    {
        [JsonProperty("autoWatch")]
        public bool AutoWatch { get; set; }

        [JsonProperty("alwaysMarkNsfw")]
        public bool AlwaysMarkNsfw { get; set; }
    }
}