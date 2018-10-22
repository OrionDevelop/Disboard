using System.Threading.Tasks;

using Disboard.Mastodon.Enums;
using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Mastodon.Test.Clients
{
    public class AuthClientTest : MastodonTestClient
    {
        [Fact]
        public async Task AccessTokenAsync()
        {
            var actual = await TestClient.Auth.AccessTokenAsync(Constants.RedirectUriForClient, "2d72992cf19f0bf3f48585565dfe0aedf2ffc10b1ac7ef891d4acf9d72b44eea");
            actual.CheckRecursively();
        }

        [Fact(Skip = "Currently, Using Real Client ID")]
        public void AuthorizeUrl()
        {
            var scopes = AccessScope.Read | AccessScope.Write | AccessScope.Follow;
            var actual = TestClient.Auth.AuthorizeUrl(Constants.RedirectUriForClient, scopes);
            actual.Is("https://mastodon.cloud/oauth/authorize?scope=read%20write%20follow&response_type=code&redirect_uri=urn%3Aietf%3Awg%3Aoauth%3A2.0%3Aoob&client_id=TEST_CLIENT_ID");
        }
    }
}