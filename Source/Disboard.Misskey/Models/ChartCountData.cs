using System.Collections.Generic;

using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class ChartCountData : ApiResponse
    {
        [JsonProperty("count")]
        public IEnumerable<long> Count { get; set; }
    }
}