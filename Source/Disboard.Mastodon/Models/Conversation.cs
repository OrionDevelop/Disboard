using System.Collections.Generic;

using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    public class Conversation : ApiResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("unread")]
        public bool IsUnread { get; set; }

        [JsonProperty("accounts")]
        public IEnumerable<Account> Accounts { get; set; }

        [JsonProperty("last_status")]
        public Status LastStatus { get; set; }
    }
}