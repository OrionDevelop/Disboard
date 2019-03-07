using System;
using System.Collections.Generic;

using Disboard.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Disboard.Misskey.Models
{
    public class Poll : ApiResponse
    {
        [JsonProperty("choices")]
        public IEnumerable<Choice> Choices { get; set; }

        [JsonProperty("expiresAt")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? ExpiresAt { get; set; }

        [JsonProperty("multiple")]
        public bool? Multiple { get; set; }
    }
}