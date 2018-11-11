using System.Linq;
using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Misskey.Test.Clients
{
    public class MuteClientTest : MisskeyTestClient
    {
        private const string Id = "5aa4f87517e79e32cef38397";

        [Fact]
        public async Task CreateAsync()
        {
            await TestClient.Mute.CreateAsync(Id);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            await TestClient.Mute.DeleteAsync(Id);
        }

        [Fact]
        public async Task ListAsync()
        {
            var actual = await TestClient.Mute.ListAsync(1);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }
    }
}