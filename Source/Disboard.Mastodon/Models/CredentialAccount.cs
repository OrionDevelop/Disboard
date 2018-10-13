using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    // https://github.com/tootsuite/mastodon/blob/v2.5.0/app/serializers/rest/credential_account_serializer.rb
    public class CredentialAccount : Account
    {
        [JsonProperty("source")]
        public Source Source { get; set; }
    }
}