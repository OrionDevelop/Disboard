using System.Linq;
using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Misskey.Test.Clients
{
    public class MyClientTest : MisskeyTestClient
    {
        [Fact]
        public async Task AppsAsync()
        {
            var actual = await TestClient.My.AppsAsync(1);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }
    }
}