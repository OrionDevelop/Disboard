using System.Threading.Tasks;

using Disboard.Extensions;

namespace Disboard.Misskey.Clients
{
    public partial class NotificationsClient : MisskeyApiClient
    {
        protected internal NotificationsClient(MisskeyClient client) : base(client, "notifications") { }

        public async Task MarkAllAsReadAsync()
        {
            await PostAsync("/mark_all_as_read").Stay();
        }
    }
}