using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class ChartDriveData2<T> : ApiResponse
    {
        [JsonProperty("totalFiles")]
        public T TotalFiles { get; set; }

        [JsonProperty("totalUsage")]
        public T TotalUsage { get; set; }

        [JsonProperty("incFiles")]
        public T IncFiles { get; set; }

        [JsonProperty("incUsage")]
        public T IncUsage { get; set; }

        [JsonProperty("decFiles")]
        public T DecFiles { get; set; }

        [JsonProperty("decUsage")]
        public T DecUsage { get; set; }
    }
}