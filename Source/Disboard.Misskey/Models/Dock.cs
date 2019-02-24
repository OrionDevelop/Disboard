using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class Dock : ApiResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("place")]
        public string Place { get; set; }

        // FIXME: 何が降ってくる？
        [JsonProperty("data")]
        public ApiResponse Data { get; set; }
    }
}