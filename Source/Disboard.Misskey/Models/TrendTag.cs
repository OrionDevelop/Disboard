using System.Collections.Generic;

using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class TrendTag : ApiResponse
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("chart")]
        public IEnumerable<int> Chart { get; set; }

        [JsonProperty("usersCount")]
        public long UsersCount { get; set; }
    }
}