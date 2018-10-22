using System.Collections.Generic;

using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    public class Results : ApiResponse
    {
        [JsonProperty("accounts")]
        public IEnumerable<Account> Accounts { get; set; }

        [JsonProperty("statuses")]
        public IEnumerable<Status> Statuses { get; set; }

        [JsonProperty("hashtags")]
        public IEnumerable<string> Hashtags { get; set; }
    }
}