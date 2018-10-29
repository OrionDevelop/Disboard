using System;

using Disboard.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Disboard.Misskey.Models
{
    public class Folder : ApiResponse
    {
        [JsonProperty("createdAt")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parentId")]
        public string ParentId { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}