using System.Collections.Generic;
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
        public async Task RecommendationAsync()
        {
            var actual = await TestClient.Users.RecommendationAsync(1);
            actual.Count.Is(1);
            actual.First().CheckRecursively(IgnoreProperties);
        }

        [Fact]
        public async Task RelationAsync()
        {
            var actual = await TestClient.Users.RelationAsync(new List<string> {"5aa4f87517e79e32cef38397"});
            actual.Count.IsNot(0);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task SearchAsync()
        {
            var actual = await TestClient.Users.SearchAsync("mika", 1, 0, false);
            actual.Count.Is(1);
            actual.First().CheckRecursively(IgnoreProperties);
        }

        [Fact]
        public async Task ShowAsync()
        {
            var actual = await TestClient.Users.ShowAsync(username: "mikazuki", host: "misskey.xyz");
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }
    }
}