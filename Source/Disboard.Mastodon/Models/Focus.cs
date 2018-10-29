using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    public class Focus
    {
        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }
    }
}