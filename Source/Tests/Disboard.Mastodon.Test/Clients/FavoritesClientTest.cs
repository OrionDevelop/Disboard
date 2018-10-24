using System.Linq;
using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Mastodon.Test.Clients
{
    public class FavoritesClientTest : MastodonTestClient
    {
        [Fact]
        public async Task ListAsync()
        {
            var actual = await TestClient.Favorites.ListAsync(1, 1, 100000);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }
    }
}