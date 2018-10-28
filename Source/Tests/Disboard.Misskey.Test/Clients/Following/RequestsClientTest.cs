using System.Linq;
using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Misskey.Test.Clients.Following
{
    public class RequestsClientTest : MisskeyTestClient
    {
        [Fact]
        public async Task AcceptAsync()
        {
            await TestClient.Following.Requests.AcceptAsync("5bcc9faab742f2004c5ba4d6");
        }

        [Fact]
        public async Task CancelAsync()
        {
            await TestClient.Following.Requests.CancelAsync("5bcc9faab742f2004c5ba4d6");
        }

        [Fact]
        public async Task ListAsync()
        {
            var actual = await TestClient.Following.Requests.ListAsync();
            actual.Count.IsNot(0);
            actual.First().CheckRecursively(IgnoreProperties);
        }

        [Fact]
        public async Task RejectAsync()
        {
            await TestClient.Following.Requests.RejectAsync("5ba4c40406bdd21ada87964b");
        }
    }
}