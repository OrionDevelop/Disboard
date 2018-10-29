using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class ChartDiffs : ApiResponse
    {
        [JsonProperty("normal")]
        public long Normal { get; set; }

        [JsonProperty("reply")]
        public long Reply { get; set; }

        [JsonProperty("renote")]
        public long Renote { get; set; }
    }
}