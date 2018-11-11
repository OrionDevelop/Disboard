using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class Maintainer : ApiResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("repository_url")]
        public string RepositoryUrl { get; set; }

        [JsonProperty("feedback_url")]
        public string FeedbackUrl { get; set; }
    }
}