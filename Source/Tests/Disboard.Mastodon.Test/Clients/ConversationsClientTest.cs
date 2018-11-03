using System.Linq;
using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Mastodon.Test.Clients
{
    public class ConversationsClientTest : MastodonTestClient
    {
        [Fact]
        public async Task DestroyAsync()
        {
            await TestClient.Conversations.DestroyAsync(460);
        }

        [Fact]
        public async Task ListAsync()
        {
            var actual = await TestClient.Conversations.ListAsync(1, 1, 1, long.MaxValue);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task ReadAsync()
        {
            var actual = await TestClient.Conversations.ReadAsync(460);
            actual.CheckRecursively();
        }
    }
}