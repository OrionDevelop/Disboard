using System.Threading.Tasks;

using Xunit;

namespace Disboard.Misskey.Test.Clients
{
    public class NotificationsClientTest : MisskeyTestClient
    {
        [Fact]
        public async Task MarkAllAsReadAsync()
        {
            await TestClient.Notifications.MarkAllAsReadAsync();
        }
    }
}