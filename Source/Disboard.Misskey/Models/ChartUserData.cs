using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class ChartUserData
    {
        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("inc")]
        public long Inc { get; set; }

        [JsonProperty("dec")]
        public long Dec { get; set; }
    }
}