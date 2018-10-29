using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class ChartLocation<T> : ApiResponse
    {
        [JsonProperty("local")]
        public T Local { get; set; }

        [JsonProperty("remote")]
        public T Remote { get; set; }
    }
}