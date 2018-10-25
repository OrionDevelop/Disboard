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

        [Fact(Skip = "FIXME")]
        public async Task ShowAsync()
        {
            var actual = await TestClient.Auth.Session.ShowAsync("TEST_ACCESS_TOKEN");
            actual.CheckRecursively();
        }

        [Fact]
        public async Task UserKeyAsync()
        {
            var actual = await TestClient.Auth.Session.UserKeyAsync("8564d8fb-8a83-4028-8413-ecc1515f6687");
            actual.CheckRecursively();
        }
    }
}