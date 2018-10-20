using System;
using System.Collections.Generic;

using Disboard.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Disboard.Misskey.Models
{
    public class App : ApiResponse
    {
        [JsonProperty("callbackUrl")]
        public string CallbackUrl { get; set; }

        [JsonProperty("createdAt")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("iconUrl")]
        public string IconUrl { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("isAuthorized")]
        public bool? IsAuthorized { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("permission")]
        public List<string> Permissions { get; set; }

        [JsonProperty("secret")]
        public string Secret { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}