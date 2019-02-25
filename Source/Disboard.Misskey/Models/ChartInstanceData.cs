using System.Collections.Generic;

using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class ChartInstanceData : ApiResponse
    {
        [JsonProperty("drive")]
        public ChartDriveData2<IEnumerable<long>> Drive { get; set; }

        [JsonProperty("following")]
        public ChartBasicData<IEnumerable<long>> Following { get; set; }

        [JsonProperty("followers")]
        public ChartBasicData<IEnumerable<long>> Followers { get; set; }

        [JsonProperty("notes")]
        public ChartBasicData<IEnumerable<long>> Notes { get; set; }

        [JsonProperty("requests")]
        public ChartRequestData Requests { get; set; }

        [JsonProperty("users")]
        public ChartBasicData<IEnumerable<long>> Users { get; set; }
    }
}