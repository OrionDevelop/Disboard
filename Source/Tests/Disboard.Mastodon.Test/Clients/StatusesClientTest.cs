using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Disboard.Exceptions;
using Disboard.Mastodon.Enums;
using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Mastodon.Test.Clients
{
    public class StatusesClientTest : MastodonTestClient
    {
        private const long Id = 100950488743368230;

        [Fact]
        public async Task CardAsync()
        {
            var actual = await TestClient.Statuses.CardAsync(Id);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task ContextAsync()
        {
            var actual = await TestClient.Statuses.ContextAsync(Id);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task DestroyAsync()
        {
            await TestClient.Statuses.DestroyAsync(Id);
        }

        [Fact]
        public async Task FavoriteAsync()
        {
            var actual = await TestClient.Statuses.FavouriteAsync(Id);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task FavouritedByAsync()
        {
            var actual = await TestClient.Statuses.FavouritedByAsync(Id);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task MuteAsync()
        {
            var actual = await TestClient.Statuses.MuteAsync(Id);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task PinAsync()
        {
            var actual = await TestClient.Statuses.PinAsync(Id);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task ReblogAsync()
        {
            var actual = await TestClient.Statuses.ReblogAsync(Id);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task RebloggedBy()
        {
            var actual = await TestClient.Statuses.RebloggedByAsync(Id);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task ShowAsync()
        {
            var actual = await TestClient.Statuses.ShowAsync(Id);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task UnfavoriteAsync()
        {
            var actual = await TestClient.Statuses.UnfavouriteAsync(Id);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task UnmuteAsync()
        {
            var actual = await TestClient.Statuses.UnmuteAsync(Id);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task UnpinAsync()
        {
            var actual = await TestClient.Statuses.UnpinAsync(Id);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task UnreblogAsync()
        {
            var actual = await TestClient.Statuses.UnreblogAsync(Id);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var actual = await TestClient.Statuses.UpdateAsync("test", null, new List<long> {8859990}, true, "Photo by CC0", VisibilityType.Public);
            actual.CheckRecursively();
        }
    }
}