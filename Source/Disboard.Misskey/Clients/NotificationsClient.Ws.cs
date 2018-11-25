using System.Threading.Tasks;

using Disboard.Extensions;

namespace Disboard.Misskey.Clients
{
    public partial class NotificationsClient
    {
        public async Task MarkAllAsReadWsAsync()
        {
            await SendWsAsync("/mark_all_as_read").Stay();
        }
    }
}