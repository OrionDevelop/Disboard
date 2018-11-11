using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class Me : User
    {
        [JsonProperty("clientSettings")]
        public ClientSettings ClientSettings { get; set; }

        [JsonProperty("settings")]
        public Settings Settings { get; set; }
    }
}