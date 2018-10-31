using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.PeerTube.Test.Clients
{
    public class OAuthClientsClientTest : PeerTubeTestClient
    {
        [Fact]
        public async Task LocalAsync()
        {
            var actual = await TestClient.OAuthClients.LocalAsync();
            actual.CheckRecursively();
        }
    }
}