using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;

namespace Disboard.Misskey.Clients
{
    public class NotificationsClient : ApiClient<MisskeyClient>
    {
        protected internal NotificationsClient(MisskeyClient client) : base(client, "/api/notifications") { }

        public async Task MarkAllAsReadAsync()
        {
            await PostAsync("/mark_all_as_read").Stay();
        }
    }
}