using System.Linq;
using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Misskey.Test.Clients.Drive
{
    public class FilesClientTest : MisskeyTestClient
    {
        [Fact]
        public async Task AttachedNotesAsync()
        {
            var actual = await TestClient.Drive.Files.AttachedNotesAsync("5bd2500ca919c80052895bbd");
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task CheckExistenceInExists()
        {
            var actual = await TestClient.Drive.Files.CheckExistence("bb84063ae69264a728e2825889adfa01");
            actual.CheckRecursively(IgnoreProperties);
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
            actual.CheckRecursively(IgnoreProperties);
        }

        [Fact(Skip = "FIXME: Test case is invalid")]
        public async Task DeleteAsync()
        {
            await TestClient.Drive.Files.DeleteAsync("5bd2500ca919c80052895bbd");
        }

        [Fact]
        public async Task ShowAsync()
        {
            var actual = await TestClient.Drive.Files.ShowAsync("5bd2500ca919c80052895bbd");
            actual.CheckRecursively(IgnoreProperties);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var actual = await TestClient.Drive.Files.UpdateAsync("5bd2500ca919c80052895bbd", null, "test.jpg", false);
            actual.CheckRecursively(IgnoreProperties);
        }

        [Fact]
        public async Task UploadFromUrl()
        {
            var actual = await TestClient.Drive.Files.UploadFromUrl("https://static.mochizuki.moe/busy_banner.png");
            actual.CheckRecursively(IgnoreProperties);
        }
    }
}