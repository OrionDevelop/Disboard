using System.Collections.Generic;

using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class ChartFollowingData : ApiResponse
    {
        [JsonProperty("followings")]
        public ChartBasicData<IEnumerable<long>> Followings { get; set; }

        [JsonProperty("followers")]
        public ChartBasicData<IEnumerable<long>> Followers { get; set; }
    }
}