using System.Linq;
using System.Threading.Tasks;

using Disboard.Exceptions;
using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Mastodon.Test.Clients
{
    public class ListsClientTest : MastodonTestClient
    {
        private const int Id = 316;

        [Fact]
        public async Task CreateAsync()
        {
            var actual = await TestClient.Lists.CreateAsync("てすと2");
            actual.Title.Is("てすと2");
            actual.CheckRecursively();
        }

        [Fact]
        public async Task DestroyAsync()
        {
            await TestClient.Lists.DestroyAsync(320);

            // record not found
            await MarkAsAnother(async client => await Assert.ThrowsAsync<DisboardException>(async () => await client.Lists.ShowAsync(320)));
        }

        [Fact]
        public async Task ListAsync()
        {
            var actual = await TestClient.Lists.ListAsync();
            actual.Count.IsNot(0);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task ShowAsync()
        {
            var actual = await TestClient.Lists.ShowAsync(Id);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var actual = await TestClient.Lists.UpdateAsync(320, "てすと3");
            actual.Title.Is("てすと3");
            actual.CheckRecursively();
        }
    }
}