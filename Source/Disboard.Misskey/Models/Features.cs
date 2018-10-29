using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class Features : ApiResponse
    {
        [JsonProperty("registration")]
        public bool Registration { get; set; }

        [JsonProperty("localTimeline")]
        public bool LocalTimeline { get; set; }

        [JsonProperty("elasticSearch")]
        public bool ElasticSearch { get; set; }

        [JsonProperty("recaptcha")]
        public bool Recaptcha { get; set; }

        [JsonProperty("objectStorage")]
        public bool ObjectStorage { get; set; }

        [JsonProperty("twitter")]
        public bool Twitter { get; set; }

        [JsonProperty("serviceWorker")]
        public bool ServiceWorker { get; set; }

        [JsonProperty("userRecommendation")]
        public UserRecommendation UserRecommendation { get; set; }
    }
}