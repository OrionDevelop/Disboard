using System.Linq;
using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Mastodon.Test.Clients
{
    public class InstanceClientTest : MastodonTestClient
    {
        [Fact]
        public async Task ActivityAsync()
        {
            var actual = await TestClient.Instance.ActivityAsync();
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task PeersAsync()
        {
            var actual = await TestClient.Instance.PeersAsync();
            actual.Count.Is(3);
            actual.First().IsInstanceOf<string>();
        }

        [Fact]
        public async Task ShowAsync()
        {
            var actual = await TestClient.Instance.ShowAsync();
            actual.CheckRecursively();
        }
    }
}