using System.Linq;
using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Mastodon.Test.Clients
{
    public class FollowRequestsClientTest : MastodonTestClient
    {
        [Fact]
        public async Task AuthorizeAsync()
        {
            await TestClient.FollowRequests.AuthorizeAsync(456646);
        }

        [Fact]
        public async Task ListAsync()
        {
            var actual = await TestClient.FollowRequests.ListAsync(1, 1, 1000000);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task RejectAsync()
        {
            await TestClient.FollowRequests.RejectAsync(456646);
        }
    }
}