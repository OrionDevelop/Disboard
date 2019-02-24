using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class ChartNoteData<T> : ChartData
    {
        [JsonProperty("total")]
        public T Total { get; set; }

        [JsonProperty("inc")]
        public T Inc { get; set; }

        [JsonProperty("dec")]
        public T Dec { get; set; }

        [JsonProperty("diffs")]
        public ChartDiffs<T> Diffs { get; set; }
    }
}