using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Misskey.Test.Clients.Auth
{
    public class SessionClientTest : MisskeyTestClient
    {
        [Fact]
        public async Task GenerateAsync()
        {
            var actual = await TestClient.Auth.Session.GenerateAsync();
            actual.CheckRecursively();
        }

        [Fact(Skip = "Token is unknown")]
        public async Task ShowAsync()
        {
            var actual = await TestClient.Auth.Session.ShowAsync("");
            actual.CheckRecursively();
        }

        [Fact]
        public async Task UserKeyAsync()
        {
            var actual = await TestClient.Auth.Session.UserKeyAsync("db5e25ba-addb-47d2-8992-da28dd25353c");
            actual.CheckRecursively();
        }
    }
}