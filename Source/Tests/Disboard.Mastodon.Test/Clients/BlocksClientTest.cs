using System.Linq;
using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Mastodon.Test.Clients
{
    public class BlocksClientTest : MastodonTestClient
    {
        [Fact]
        public async Task ListAsync()
        {
            var actual = await TestClient.Blocks.ListAsync(1, 1, 1000000);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }
    }
}