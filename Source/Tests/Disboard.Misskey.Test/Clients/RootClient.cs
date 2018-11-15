using System.Linq;
using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Misskey.Test.Clients
{
    public class RootClient : MisskeyTestClient
    {
        [Fact(Skip = "Test data is broken")]
        public async Task ChartAsync()
        {
            var actual = await TestClient.ChartAsync(1);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task DriveAsync()
        {
            var actual = await TestClient.DriveAsync();
            actual.CheckRecursively();
        }

        // ReSharper disable once InconsistentNaming
        [Fact]
        public async Task IAsync()
        {
            var actual = await TestClient.IAsync();
            actual.CheckRecursively();
        }

        [Fact]
        public async Task MetaAsync()
        {
            var actual = await TestClient.MetaAsync();
            actual.CheckRecursively();
        }

        [Fact]
        public async Task NotesAsync()
        {
            var actual = await TestClient.NotesAsync(false, false, false, false, false, 1);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task StatsAsync()
        {
            var actual = await TestClient.StatsAsync();
            actual.CheckRecursively();
        }

        [Fact]
        public async Task UsersAsync()
        {
            var actual = await TestClient.UsersAsync(1, 0, "+follower");
            actual.Count.Is(1);
            actual.First().CheckRecursively(IgnoreProperties);
        }
    }
}