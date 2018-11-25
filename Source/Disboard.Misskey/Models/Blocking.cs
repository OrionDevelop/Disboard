using System;

using Disboard.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Disboard.Misskey.Models
{
    public class Blocking : ApiResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("blockerId")]
        public string BlockerId { get; set; }

        [JsonProperty("blockeeId")]
        public string BlockeeId { get; set; }

        [JsonProperty("blockee")]
        public User Blockee { get; set; }

        [JsonProperty("createdAt")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreatedAt { get; set; }
    }
}