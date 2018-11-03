using System;

using Disboard.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Disboard.Misskey.Models
{
    public class Muting : ApiResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdAt")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("mutee")]
        public User Mutee { get; set; }

        [JsonProperty("muteeId")]
        public string MuteeId { get; set; }

        [JsonProperty("muterId")]
        public string MuterId { get; set; }
    }
}