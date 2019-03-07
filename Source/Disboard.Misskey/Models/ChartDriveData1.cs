using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class ChartDriveData1<T> : ApiResponse
    {
        [JsonProperty("totalCount")]
        public T TotalCount { get; set; }

        [JsonProperty("totalSize")]
        public T TotalSize { get; set; }

        [JsonProperty("incCount")]
        public T IncCount { get; set; }

        [JsonProperty("incSize")]
        public T IncSize { get; set; }

        [JsonProperty("decCount")]
        public T DecCount { get; set; }

        [JsonProperty("decSize")]
        public T DecSize { get; set; }
    }
}