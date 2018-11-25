using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Disboard.Mastodon.Models;
using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Mastodon.Test.Clients
{
    public class AccountsClientTest : MastodonTestClient
    {
        private const long Id = 31061;

        [Fact]
        public async Task BlockAsync()
        {
            var actual = await TestClient.Account.BlockAsync(1);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task FollowAsync()
        {
            var actual = await TestClient.Account.FollowAsync(1, true);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task FollowersAsync()
        {
            var actual = await TestClient.Account.FollowersAsync(Id, 1, 50000, 100000);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task FollowingAsync()
        {
            var actual = await TestClient.Account.FollowingAsync(Id, 1, 50000, 100000);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact(Skip = "FIXME: Get a valid real response for tests")]
        public async Task ListsAsync()
        {
            var actual = await TestClient.Account.ListsAsync(Id);
            actual.IsNotNull();
        }

        [Fact]
        public async Task MuteAsync()
        {
            var actual = await TestClient.Account.MuteAsync(1, true);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task PinAsync()
        {
            var actual = await TestClient.Account.PinAsync(1);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task RelationShipsAsync()
        {
            var actual = await TestClient.Account.RelationshipsAsync(new List<long> {66051, 47754, 12111});
            actual.Count.Is(3);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task SearchAsync()
        {
            var actual = await TestClient.Account.SearchAsync("みか", 1, false, false);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task ShowAsync()
        {
            var actual = await TestClient.Account.ShowAsync(Id);
            actual.CheckRecursively();
        }

        [Fact(Skip = "Test response is broken on 2.6.1")]
        public async Task StatusesAsync()
        {
            var actual = await TestClient.Account.StatusesAsync(Id, 1, 1, 1, 1000000, false, false, true);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task UnblockAsync()
        {
            var actual = await TestClient.Account.UnblockAsync(1);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task UnfollowAsync()
        {
            var actual = await TestClient.Account.UnfollowAsync(1);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task UnmuteAsync()
        {
            var actual = await TestClient.Account.UnmuteAsync(1);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task UnpinAsync()
        {
            var actual = await TestClient.Account.UnpinAsync(1);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task UpdateCredentialsAsync()
        {
            var actual = await TestClient.Account.UpdateCredentialsAsync(isBot: false, source: new Source {IsSensitive = false});
            actual.CheckRecursively();
        }

        [Fact]
        public async Task VerifyCredentialsAsync()
        {
            var actual = await TestClient.Account.VerifyCredentialsAsync();
            actual.CheckRecursively();
        }
    }
}