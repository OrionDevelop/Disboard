using System.Linq;
using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Mastodon.Test.Clients
{
    public class SuggestionsClientTest : MastodonTestClient
    {
        [Fact(Skip = "FIXME: Get a valid real data for tests")]
        public async Task DestroyAsync()
        {
            await TestClient.Suggestions.DestroyAsync(287862);
        }

        [Fact(Skip = "FIXME: Get a valid real data for tests")]
        public async Task ListAsync()
        {
            var actual = await TestClient.Suggestions.ListAsync(1);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }
    }
}