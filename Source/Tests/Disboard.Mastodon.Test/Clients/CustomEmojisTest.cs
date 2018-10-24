using System.Linq;
using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Mastodon.Test.Clients
{
    public class CustomEmojisTest : MastodonTestClient
    {
        [Fact]
        public async Task ShowAsync()
        {
            var actual = await TestClient.CustomEmojis.ShowAsync();
            actual.Count.IsNot(0);
            actual.First().CheckRecursively();
        }
    }
}