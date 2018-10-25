using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Misskey.Test.Clients.Drive
{
    public class FilesClientTest : MisskeyTestClient
    {
        [Fact]
        public async Task CheckExistenceInExists()
        {
            var actual = await TestClient.Drive.Files.CheckExistence("bb84063ae69264a728e2825889adfa01");
            actual.CheckRecursively();
        }

        [Fact]
        public async Task CheckExistenceInNotExists()
        {
            var actual = await TestClient.Drive.Files.CheckExistence("bb84063ae69364a728e2825889adfa01");
            actual.IsNull();
        }

        [Fact(Skip = "Hashed-Key is indeterminate")]
        public async Task CreateAsync()
        {
            var actual = await TestClient.Drive.Files.CreateAsync("./data/photo.jpg", "5bcb51c1ccba9f002ebb1452");
            actual.CheckRecursively();
        }

        [Fact]
        public async Task DeleteAsync()
        {
            await TestClient.Drive.Files.DeleteAsync("5bd24b02a919c80052895a86");
        }

        [Fact]
        public async Task ShowAsync()
        {
            var actual = await TestClient.Drive.Files.ShowAsync("5bd24b02a919c80052895a86");
            actual.CheckRecursively();
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var actual = await TestClient.Drive.Files.UpdateAsync("5bd24b02a919c80052895a86", null, "test.jpg", false);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task UploadFromUrl()
        {
            var actual = await TestClient.Drive.Files.UploadFromUrl("https://static.mochizuki.moe/busy_banner.png");
            actual.CheckRecursively();
        }
    }
}