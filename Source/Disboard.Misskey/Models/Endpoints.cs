using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class Endpoints : ApiResponse
    {
        [JsonProperty("sharedInbox")]
        public string SharedInbox { get; set; }
    }
}