using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Misskey.Test.Clients.Messaging
{
    public class MessagesClientTest : MisskeyTestClient
    {
        [Fact(Skip = "FIXME")]
        public async Task CreateAsync()
        {
            var actual = await TestClient.Messaging.Messages.CreateAsync("FIXME", "Hello, World", "FIXMEs");
            actual.CheckRecursively();
        }

        [Fact(Skip = "FIXME")]
        public async Task ReadAsync()
        {
            await TestClient.Messaging.Messages.ReadAsync("FIXME");
        }
    }
}