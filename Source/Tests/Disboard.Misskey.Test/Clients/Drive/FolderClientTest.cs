using System.Linq;
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
            var actual = await TestClient.Drive.Folders.CreateAsync("CI.TESTING", "5bd32b5eaffd0600284f6f00");
            actual.CheckRecursively();
        }

        [Fact]
        public async Task DeleteAsync()
        {
            await TestClient.Drive.Folders.DeleteAsync("5bd32b97bde21c004b2c3248");
        }

        [Fact]
        public async Task FindAsync()
        {
            var actual = await TestClient.Drive.Folders.FindAsync("CI.TESTING", "5bd32b5eaffd0600284f6f00");
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task ShowAsync()
        {
            var actual = await TestClient.Drive.Folders.ShowAsync("5bd32b97bde21c004b2c3248");
            actual.CheckRecursively();
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var actual = await TestClient.Drive.Folders.UpdateAsync("5bd32b97bde21c004b2c3248", "CI.TESTED", "5bd32b5eaffd0600284f6f00");
            actual.CheckRecursively();
        }
    }
}