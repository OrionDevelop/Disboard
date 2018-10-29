using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class Cpu : ApiResponse
    {
        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("cores")]
        public int Cores { get; set; }
    }
}