using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class ChartDriveData : ApiResponse
    {
        [JsonProperty("totalCount")]
        public long TotalCount { get; set; }

        [JsonProperty("totalSize")]
        public long TotalSize { get; set; }

        [JsonProperty("incCount")]
        public long IncCount { get; set; }

        [JsonProperty("incSize")]
        public long IncSize { get; set; }

        [JsonProperty("decCount")]
        public long DecCount { get; set; }

        [JsonProperty("decSize")]
        public long DecSize { get; set; }
    }
}