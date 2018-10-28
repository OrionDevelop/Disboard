using System.Threading.Tasks;

using Xunit;

namespace Disboard.Misskey.Test.Clients
{
    public class UsernameClientTest : MisskeyTestClient
    {
        [Fact]
        public async Task AvailableAsync()
        {
            var actual = await TestClient.Username.AvailableAsync("mikazuki");
            actual.Is(false);
        }
    }
}