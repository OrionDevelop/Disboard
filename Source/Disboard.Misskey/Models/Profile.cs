using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class Profile : ApiResponse
    {
        [JsonProperty("bio")]
        public string Bio { get; set; }

        [JsonProperty("birthday")]
        public string Birthday { get; set; }

        [JsonProperty("blood")]
        public string Blood { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("handedness")]
        public string Handedness { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }
    }
}