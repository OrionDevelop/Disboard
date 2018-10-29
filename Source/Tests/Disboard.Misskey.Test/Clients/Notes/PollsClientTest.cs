using System.Linq;
using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Misskey.Test.Clients.Notes
{
    public class PollsClientTest : MisskeyTestClient
    {
        [Fact]
        public async Task RecommendationAsync()
        {
            var actual = await TestClient.Notes.Polls.RecommendationAsync(1, 0);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task VoteAsync()
        {
            await TestClient.Notes.Polls.VoteAsync("5bd3ffc03e985d005011cc83", 1);
        }
    }
}