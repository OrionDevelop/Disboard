using System;

using Disboard.Converters;
using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class CountAggregation : ApiResponse
    {
        [JsonProperty("date")]
        [JsonConverter(typeof(DateObjectToDateTimeConverter))]
        public DateTime Date { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }
    }
}