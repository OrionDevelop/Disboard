using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Misskey.Test.Clients.Drive
{
    public class FolderClientTest : MisskeyTestClient
    {
        [Fact]
        public async Task CreateAsync()
        {
            var actual = await TestClient.Drive.Folders.CreateAsync("Disboard", "5bcb51c1ccba9f002ebb1452");
            actual.CheckRecursively();
        }

        [Fact]
        public async Task ShowAsync()
        {
            var actual = await TestClient.Drive.Folders.ShowAsync("5bd2f7b0f85f76002f959e4a");
            actual.CheckRecursively();
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var actual = await TestClient.Drive.Folders.UpdateAsync("5bd2f7b0f85f76002f959e4a", "Disboard.Test", "5bd2f790f9e541004adf7efb");
            actual.CheckRecursively();
        }
    }
}