using System.Linq;
using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Misskey.Test.Clients
{
    public class AggregationClientTest : MisskeyTestClient
    {
        [Fact]
        public async Task HashtagsAsync()
        {
            var actual = await TestClient.Aggregation.HashtagsAsync();
            actual.Count.IsNot(1);
            actual.First().CheckRecursively();
        }
    }
}