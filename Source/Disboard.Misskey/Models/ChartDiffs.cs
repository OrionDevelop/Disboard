using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class ChartDiffs<T> : ApiResponse
    {
        [JsonProperty("normal")]
        public T Normal { get; set; }

        [JsonProperty("reply")]
        public T Reply { get; set; }

        [JsonProperty("renote")]
        public T Renote { get; set; }
    }
}