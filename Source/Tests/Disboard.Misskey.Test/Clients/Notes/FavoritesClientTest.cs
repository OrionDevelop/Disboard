using System.Threading.Tasks;

using Xunit;

namespace Disboard.Misskey.Test.Clients.Notes
{
    public class FavoritesClientTest : MisskeyTestClient
    {
        private const string Id = "5bd08d2fcd15d400274a75c4";

        [Fact]
        public async Task CreateAsync()
        {
            await TestClient.Notes.FavoritesClient.CreateAsync(Id);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            await TestClient.Notes.FavoritesClient.DeleteAsync(Id);
        }
    }
}