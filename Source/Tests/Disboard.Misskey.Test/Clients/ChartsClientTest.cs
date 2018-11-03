using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Misskey.Test.Clients
{
    public class ChartsClientTest : MisskeyTestClient
    {
        [Fact]
        public async Task DriveAsync()
        {
            var actual = await TestClient.Charts.DriveAsync("hour", 1);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task FederationAsync()
        {
            var actual = await TestClient.Charts.FederationAsync("hour", 1);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task HashtagAsync()
        {
            var actual = await TestClient.Charts.HashtagAsync("Misskey", "hour", 1);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task NetworkAsync()
        {
            var actual = await TestClient.Charts.NetworkAsync("hour", 1);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task NotesAsync()
        {
            var actual = await TestClient.Charts.NoteAsync("hour", 1);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task UsersAsync()
        {
            var actual = await TestClient.Charts.UsersAsync("hour", 1);
            actual.CheckRecursively();
        }
    }
}