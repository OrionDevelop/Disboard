using System;

using Disboard.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Disboard.Misskey.Models
{
    public class AuthSession : ApiResponse
    {
        [JsonProperty("app")]
        public App App { get; set; }

        [JsonProperty("appId")]
        public string AppId { get; set; }

        [JsonProperty("createdAt")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}