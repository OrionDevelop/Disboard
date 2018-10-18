using Disboard.Clients;
using Disboard.Misskey.Clients.Auth;

namespace Disboard.Misskey.Clients
{
    public class AuthClient : ApiClient<MisskeyClient>
    {
        public SessionClient Session { get; }

        protected internal AuthClient(MisskeyClient client) : base(client, "/api/auth")
        {
            Session = new SessionClient(client);
        }
    }
}