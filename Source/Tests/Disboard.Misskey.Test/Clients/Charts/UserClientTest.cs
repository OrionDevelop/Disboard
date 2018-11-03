using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Misskey.Test.Clients.Charts
{
    public class UserClientTest : MisskeyTestClient
    {
        private const string Id = "5ba4c40406bdd21ada87964b";

        [Fact]
        public async Task DriveAsync()
        {
            var actual = await TestClient.Charts.Users.DriveAsync(Id, "hour", 1);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task FollowingAsync()
        {
            var actual = await TestClient.Charts.Users.FollowingAsync(Id, "hour", 1);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task NotesAsync()
        {
            var actual = await TestClient.Charts.Users.NotesAsync(Id, "hour", 1);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task ReactionsAsync()
        {
            var actual = await TestClient.Charts.Users.ReactionsAsync(Id, "hour", 1);
            actual.CheckRecursively();
        }
    }
}