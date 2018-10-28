using System.Linq;
using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Misskey.Test.Clients
{
    public class UsersClientTest : MisskeyTestClient
    {
        [Fact]
        public async Task FollowersAsync()
        {
            var actual = await TestClient.Users.FollowersAsync("5ba4c40406bdd21ada87964b", false, 1, null);
            actual.Users.Count().Is(1);
            actual.Users.First().CheckRecursively();
        }

        [Fact]
        public async Task FollowingAsync()
        {
            var actual = await TestClient.Users.FollowersAsync("5ba4c40406bdd21ada87964b", false, 1, null);
            actual.Users.Count().Is(1);
            actual.Users.First().CheckRecursively();
        }

        [Fact]
        public async Task GetFrequentlyRepliedUsersAsync()
        {
            var actual = await TestClient.Users.GetFrequentlyRepliedUsersAsync("5ba4c40406bdd21ada87964b", 1);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task NotesAsync()
        {
            var actual = await TestClient.Users.NotesAsync("5ba4c40406bdd21ada87964b", null, null, true, 1, null, null, null, null, false, false, true);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task RecommentationAsync() { }

        [Fact]
        public async Task SearchAsync() { }

        [Fact]
        public async Task ShowAsync() { }
    }
}