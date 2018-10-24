using System.Linq;
using System.Threading.Tasks;

using Xunit;

namespace Disboard.Mastodon.Test.Clients
{
    public class DomainBlocksClientTest : MastodonTestClient
    {
        [Fact]
        public async Task CreateAsync()
        {
            await TestClient.DomainBlocks.CreateAsync("friends.nico");

            var actual = await TestClient.DomainBlocks.ListAsync(1, 1, 10000);
            actual.Count.Is(1);
            actual.First().Is("friends.nico");
        }

        [Fact]
        public async Task DestroyAsync()
        {
            await TestClient.DomainBlocks.DestroyAsync("friends.nico");

            var actual = await TestClient.DomainBlocks.ListAsync(1, 1, 10001);
            actual.Count.Is(0);
        }

        [Fact]
        public async Task ListAsync()
        {
            var actual = await TestClient.DomainBlocks.ListAsync(1, 1, 10000);
            actual.Count.Is(1);
        }
    }
}