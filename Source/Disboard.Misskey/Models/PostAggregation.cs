using System;

using Disboard.Converters;
using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class PostAggregation : ApiResponse
    {
        [JsonProperty("date")]
        [JsonConverter(typeof(DateObjectToDateTimeConverter))]
        public DateTime Date { get; set; }

        [JsonProperty("notes")]
        public long Notes { get; set; }

        [JsonProperty("renotes")]
        public long Renotes { get; set; }

        [JsonProperty("replies")]
        public long Replies { get; set; }
    }
}