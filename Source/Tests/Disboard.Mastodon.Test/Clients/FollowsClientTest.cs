using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Mastodon.Test.Clients
{
    public class FollowsClientTest : MastodonTestClient
    {
        [Fact]
        public async Task RemoteAsync()
        {
            var actual = await TestClient.Follows.RemoteAsync("mikazuki@friends.nico");
            actual.CheckRecursively();
        }
    }
}