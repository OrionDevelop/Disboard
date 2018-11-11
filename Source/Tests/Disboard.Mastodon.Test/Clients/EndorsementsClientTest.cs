using System.Linq;
using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Mastodon.Test.Clients
{
    public class EndorsementsClientTest : MastodonTestClient
    {
        [Fact(Skip = "FIXME: Get a valid real data for tests")]
        public async Task ListAsync()
        {
            var actual = await TestClient.Endorsements.ListAsync(1, 1, 1000000);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }
    }
}