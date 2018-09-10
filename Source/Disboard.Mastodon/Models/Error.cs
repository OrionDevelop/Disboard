using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    public class Error : ApiResponse
    {
        [JsonProperty("error")]
        public string ErrorDesc { get; set; }
    }
}