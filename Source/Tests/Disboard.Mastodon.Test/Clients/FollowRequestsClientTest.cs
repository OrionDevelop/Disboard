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
            var previous = await TestClient.FollowRequests.ListAsync(1, 1, 1000000);
            previous.Count.Is(1);

            await TestClient.FollowRequests.AuthorizeAsync(previous.First().Id);

            await MarkAsAnother(async client =>
            {
                // Should check followers count?
                var current = await client.FollowRequests.ListAsync(1, 1, 1000000);
                current.Count.Is(0);
            });
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
            var previous = await TestClient.FollowRequests.ListAsync(1, 1, 1000000);
            previous.Count.Is(1);

            await TestClient.FollowRequests.RejectAsync(previous.First().Id);

            await MarkAsAnother(async client =>
            {
                // Should check followers count?
                var current = await client.FollowRequests.ListAsync(1, 1, 1000000);
                current.Count.Is(0);
            });
        }
    }
}