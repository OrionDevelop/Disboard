using System.Threading.Tasks;

using Disboard.Mastodon.Enums;
using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Mastodon.Test.Clients
{
    public class AppsClientTest : MastodonTestClient
    {
        [Fact]
        public async Task RegisterAsync()
        {
            var scopes = AccessScope.Read | AccessScope.Write | AccessScope.Follow;
            var actual = await TestClient.Apps.RegisterAsync("Orion Test", Constants.RedirectUriForClient, scopes, "https://mochizuki.moe");
            actual.CheckRecursively();
        }

        [Fact]
        public async Task VerifyCredentialsAsync()
        {
            var actual = await TestClient.Apps.VerifyCredentialsAsync();
            actual.CheckRecursively();
        }
    }
}