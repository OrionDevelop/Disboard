using System.Linq;
using System.Threading.Tasks;

using Disboard.Mastodon.Enums;
using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Mastodon.Test.Clients
{
    public class NotificationsClientTest : MastodonTestClient
    {
        [Fact]
        public async Task ClearAsync()
        {
            await TestClient.Notifications.ClearAsync();
        }

        [Fact]
        public async Task DismissAsync()
        {
            await TestClient.Notifications.DismissAsync(999371);
        }

        [Fact]
        public async Task ListAsync()
        {
            var actual = await TestClient.Notifications.ListAsync(1, 1, 1000000, NotificationType.Reblog);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task ShowAsync()
        {
            var actual = await TestClient.Notifications.ShowAsync(999371);
            actual.CheckRecursively();
        }
    }
}