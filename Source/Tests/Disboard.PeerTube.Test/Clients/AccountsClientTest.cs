using System.Linq;
using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.PeerTube.Test.Clients
{
    public class AccountsClientTest : PeerTubeTestClient
    {
        [Fact]
        public async Task FindByNameAsync()
        {
            var actual = await TestClient.Accounts.FindByNameAsync("mikazuki", "-createdAt", 0);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task VideosAsync()
        {
            var actual = await TestClient.Accounts.VideosAsync("mikazuki");
            actual.First().CheckRecursively();
        }
    }
}