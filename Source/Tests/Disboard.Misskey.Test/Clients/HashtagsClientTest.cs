using System.Linq;
using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Misskey.Test.Clients
{
    public class HashtagsClientTest : MisskeyTestClient
    {
        [Fact]
        public async Task SearchAsync()
        {
            var actual = await TestClient.Hashtags.SearchAsync("Misskey", 1, 0);
            actual.Count.Is(1);
            actual.First().IsInstanceOf<string>();
        }

        [Fact]
        public async Task TrendAsync()
        {
            var actual = await TestClient.Hashtags.TrendAsync();
            actual.Count.IsNot(0);
            actual.First().CheckRecursively();
        }
    }
}