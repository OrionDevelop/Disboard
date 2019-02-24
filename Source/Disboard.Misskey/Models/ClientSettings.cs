using System.Collections.Generic;

using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class ClientSettings : ApiResponse
    {
        [JsonProperty("home")]
        public IEnumerable<Dock> Home { get; set; }

        [JsonProperty("deck")]
        public Deck Deck { get; set; }

        [JsonProperty("gradientWindowHeader")]
        public bool GradientWindowHeader { get; set; }

        [JsonProperty("roundedCorners")]
        public bool RoundedCorners { get; set; }

        [JsonProperty("showFullAcct")]
        public bool ShowFullAcct { get; set; }
    }
}