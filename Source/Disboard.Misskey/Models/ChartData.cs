using System;

using Disboard.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Disboard.Misskey.Models
{
    public class ChartData : ApiResponse
    {
        [JsonProperty("date")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime Date { get; set; }

        [JsonProperty("users")]
        public ChartLocation<ChartBasicData<long>> Users { get; set; }

        [JsonProperty("notes")]
        public ChartLocation<ChartNoteData<long>> Notes { get; set; }

        [JsonProperty("drive")]
        public ChartLocation<ChartDriveData1<long>> Drive { get; set; }

        [JsonProperty("network")]
        public ChartNetworkData<long> Network { get; set; }
    }
}