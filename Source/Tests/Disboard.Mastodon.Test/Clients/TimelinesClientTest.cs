using System.Linq;
using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Mastodon.Test.Clients
{
    public class TimelinesClientTest : MastodonTestClient
    {
        [Fact]
        public async Task DirectAsync()
        {
            var actual = await TestClient.Timelines.DirectAsync(false, 1, 1, long.MaxValue);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task HomeAsync()
        {
            var actual = await TestClient.Timelines.HomeAsync(false, 1, 1, long.MaxValue);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact(Skip = "FIXME: Get a valid real data for tests")]
        public async Task ListAsync()
        {
            var actual = await TestClient.Timelines.ListAsync(0, 1, 1, long.MaxValue);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task PublicAsync()
        {
            var actual = await TestClient.Timelines.PublicAsync(false, false, 1, 1, long.MaxValue);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task TagAsync()
        {
            var actual = await TestClient.Timelines.TagAsync("Mastodon", false, false, 1, 1, long.MaxValue);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }
    }
}