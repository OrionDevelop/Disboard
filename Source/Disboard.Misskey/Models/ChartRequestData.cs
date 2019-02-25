using System.Collections.Generic;

using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class ChartRequestData : ApiResponse
    {
        [JsonProperty("failed")]
        public IEnumerable<long> Failed { get; set; }

        [JsonProperty("succeeded")]
        public IEnumerable<long> Succeeded { get; set; }

        [JsonProperty("received")]
        public IEnumerable<long> Received { get; set; }
    }
}