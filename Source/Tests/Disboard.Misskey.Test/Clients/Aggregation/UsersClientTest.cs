using System.Linq;
using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Misskey.Test.Clients.Aggregation
{
    public class UsersClientTest : MisskeyTestClient
    {
        private const string Id = "5ba4c40406bdd21ada87964b";

        [Fact]
        public async Task ActivityAsync()
        {
            var actual = await TestClient.Aggregation.Users.ActivityAsync(Id, 1);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task FollowersAsync()
        {
            var actual = await TestClient.Aggregation.Users.FollowersAsync(Id);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task FollowingAsync()
        {
            var actual = await TestClient.Aggregation.Users.FollowingAsync(Id);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task PostAsync()
        {
            var actual = await TestClient.Aggregation.Users.PostAsync(Id);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task ReactionAsync()
        {
            var actual = await TestClient.Aggregation.Users.ReactionAsync(Id);
            actual.First().CheckRecursively();
        }
    }
}