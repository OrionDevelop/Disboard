using System.Threading.Tasks;

using Disboard.Extensions;

namespace Disboard.Misskey.Clients
{
    public partial class NotificationsClient
    {
        public async Task MarkAllAsReadWsAsync()
        {
            await SendWsAsync("/mark-all-as-read").Stay();
        }
    }
}