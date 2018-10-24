using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Mastodon.Test.Clients
{
    public class SearchV1ClientTest : MastodonTestClient
    {
        [Fact]
        public async Task SearchAsync()
        {
            var actual = await TestClient.SearchV1.SearchAsync("Mastodon", false);
            actual.CheckRecursively();
        }
    }
}