using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    // https://github.com/tootsuite/mastodon/blob/master/app/serializers/rest/application_serializer.rb
    public class Application : ApiResponse
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }
    }
}