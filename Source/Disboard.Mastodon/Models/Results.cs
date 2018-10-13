using System.Collections.Generic;

using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    public class Results : ApiResponse
    {
        [JsonProperty("accounts")]
        public List<Account> Accounts { get; set; }

        [JsonProperty("statuses")]
        public List<Status> Statuses { get; set; }

        [JsonProperty("hashtags")]
        public List<string> Hashtags { get; set; }
    }
}