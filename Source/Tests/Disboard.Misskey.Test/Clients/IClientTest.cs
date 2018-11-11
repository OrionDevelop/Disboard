using System.Linq;
using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Misskey.Test.Clients
{
    // ReSharper disable once InconsistentNaming
    public class IClientTest : MisskeyTestClient
    {
        [Fact(Skip = "Permissions Upgrade Required: Please see https://misskey.xyz/notes/5bd30a09d81b68004462dece")]
        public async Task FavoritesAsync()
        {
            var actual = await TestClient.I.FavoritesAsync(1);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task NotificationsAsync()
        {
            var actual = await TestClient.I.NotificationsAsync(false, true, 1);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task PinAsync()
        {
            var actual = await TestClient.I.PinAsync("5bd32cfbbde21c004b2c32b4");
            actual.CheckRecursively();
        }

        [Fact]
        public async Task ReadAllUnreadNotesAsync()
        {
            await TestClient.I.ReadAllUnreadNotesAsync();
        }

        [Fact]
        public async Task UnpinAsync()
        {
            var actual = await TestClient.I.UnpinAsync("5bd32cfbbde21c004b2c32b4");
            actual.CheckRecursively();
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var actual = await TestClient.I.UpdateAsync("みか", location: "Tokyo, Japan");
            actual.CheckRecursively();
        }
    }
}