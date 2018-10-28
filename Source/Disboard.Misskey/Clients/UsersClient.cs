using Disboard.Clients;
using Disboard.Misskey.Clients.Users;

namespace Disboard.Misskey.Clients
{
    public class UsersClient : ApiClient<MisskeyClient>
    {
        public ListsClient Lists { get; }

        protected internal UsersClient(MisskeyClient client) : base(client, "/api/users")
        {
            Lists = new ListsClient(client);
        }
    }
}