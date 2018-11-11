using System.Linq;
using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Misskey.Test.Clients
{
    public class MessagingClient : MisskeyTestClient
    {
        [Fact(Skip = "FIXME")]
        public async Task HistoryAsync()
        {
            var actual = await TestClient.Messaging.HistoryAsync(1);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact(Skip = "FIXME")]
        public async Task MessagesAsync()
        {
            var actual = await TestClient.Messaging.MessagesAsync("FIXME", true, 1);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }
    }
}