using System.Linq;
using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Misskey.Test.Clients
{
    public class DriveClientTest : MisskeyTestClient
    {
        [Fact]
        public async Task FilesAsync()
        {
            var actual = await TestClient.Drive.FilesAsync("5bcb60a1ccba9f002ebb1715", limit: 1);
            actual.Count.Is(1);
            actual.First().CheckRecursively("_user");
        }

        [Fact]
        public async Task ShowAsync()
        {
            var actual = await TestClient.Drive.ShowAsync();
            actual.CheckRecursively();
        }
    }
}