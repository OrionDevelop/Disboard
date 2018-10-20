using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
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

        public async Task AcceptAsync(string token)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("token", token)};

            await PostAsync("/accept", parameters).Stay();
        }
    }
}