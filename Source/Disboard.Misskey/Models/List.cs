using System;
using System.Collections.Generic;

using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class List : ApiResponse
    {
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("userIds")]
        public IEnumerable<string> UserIds { get; set; }
    }
}