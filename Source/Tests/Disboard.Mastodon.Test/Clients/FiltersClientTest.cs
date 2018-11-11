using System.Linq;
using System.Threading.Tasks;

using Disboard.Mastodon.Enums;
using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Mastodon.Test.Clients
{
    public class FiltersClientTest : MastodonTestClient
    {
        [Fact]
        public async Task CreateAsync()
        {
            var actual = await TestClient.Filters.CreateAsync("test", FilterContext.Public | FilterContext.Home, 3600, false, true);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task DestroyAsync()
        {
            await TestClient.Filters.DestroyAsync(228);
        }

        [Fact]
        public async Task ListAsync()
        {
            var actual = await TestClient.Filters.ListAsync();
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task ShowAsync()
        {
            var actual = await TestClient.Filters.ShowAsync(228);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var actual = await TestClient.Filters.UpdateAsync(228, "test2", isIrreversible: true);
            actual.Phrase.Is("test2");
            actual.IsIrreversible.Is(true);
            actual.CheckRecursively();
        }
    }
}