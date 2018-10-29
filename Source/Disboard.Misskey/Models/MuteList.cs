using System.Collections.Generic;

using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class MuteList : ApiResponse
    {
        [JsonProperty("users")]
        public IEnumerable<User> Users { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }
    }
}