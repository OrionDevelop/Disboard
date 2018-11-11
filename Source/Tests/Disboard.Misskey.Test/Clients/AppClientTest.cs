using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Misskey.Test.Clients
{
    public class AppClientTest : MisskeyTestClient
    {
        [Fact]
        public async Task CreateAsync()
        {
            var permissions = new[] {"account-read", "account-write", "note-write", "reaction-write", "following-write", "drive-read", "drive-write", "notification-write", "notification-read"};
            var actual = await TestClient.App.CreateAsync("Disboard Test", "Disboard Tester", permissions, "https://static.mochizuki.moe/callback.html");
            actual.CheckRecursively();
        }

        [Fact]
        public async Task ShowAsync()
        {
            var actual = await TestClient.App.ShowAsync("5bd2449634d7d2003d85f02c");
            actual.CheckRecursively();
        }
    }
}