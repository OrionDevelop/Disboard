using System.Collections.Generic;

using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class Chart : ApiResponse
    {
        [JsonProperty("perDay")]
        public IEnumerable<ChartData> PerDay { get; set; }

        [JsonProperty("perHour")]
        public IEnumerable<ChartData> PerHour { get; set; }
    }
}