using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class Twitter : ApiResponse
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("screenName")]
        public string ScreenName { get; set; }
    }
}