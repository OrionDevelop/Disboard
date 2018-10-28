using System.Threading.Tasks;

using Disboard.Clients;

namespace Disboard.Misskey.Clients
{
    public class NotificationsClient : ApiClient<MisskeyClient>
    {
        protected internal NotificationsClient(MisskeyClient client) : base(client, "/api/notifications") { }

        public async Task MarkAllAsReadAsync()
        {
            await PostAsync("/mark_all_as_read");
        }
    }
}