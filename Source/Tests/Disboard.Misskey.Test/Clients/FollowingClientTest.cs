using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Misskey.Test.Clients
{
    public class FollowingClientTest : MisskeyTestClient
    {
        private const string Id = "5aa4f87517e79e32cef38397";

        [Fact]
        public async Task CreateAsync()
        {
            var actual = await TestClient.Following.CreateAsync(Id);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var actual = await TestClient.Following.DeleteAsync(Id);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task StalkAsync()
        {
            await TestClient.Following.StalkAsync(Id);
        }

        [Fact]
        public async Task UnstalkAsync()
        {
            await TestClient.Following.UnstalkAsync(Id);
        }
    }
}