using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Mastodon.Test.Clients
{
    public class ReportsClient : MastodonTestClient
    {
        [Fact(Skip = "FIXME: Get a valid real data for tests")]
        public async Task CreateAsync()
        {
            var actual = await TestClient.Reports.CreateAsync(0, "comment", true, new List<long> {0});
            actual.CheckRecursively();
        }

        [Fact(Skip = "FIXME: Get a valid real data for tests")]
        public async Task ListAsync()
        {
            var actual = await TestClient.Reports.ListAsync();
            actual.First().CheckRecursively();
        }
    }
}