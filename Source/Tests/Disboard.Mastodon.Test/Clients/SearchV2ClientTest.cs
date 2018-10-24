using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Mastodon.Test.Clients
{
    public class SearchV2ClientTest : MastodonTestClient
    {
        [Fact]
        public async Task SearchAsync()
        {
            var actual = await TestClient.SearchV2.SearchAsync("Mastodon", false);
            actual.CheckRecursively();
        }
    }
}