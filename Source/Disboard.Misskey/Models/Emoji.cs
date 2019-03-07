using System;
using System.Collections.Generic;

using Disboard.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Disboard.Misskey.Models
{
    public class Emoji : ApiResponse
    {
        [JsonProperty("aliases")]
        public List<string> Aliases { get; set; }

        [JsonProperty("updatedAt")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}