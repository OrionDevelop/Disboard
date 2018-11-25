using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.PeerTube.Models;

namespace Disboard.PeerTube.Clients
{
    public class UsersClient : ApiClient<PeerTubeClient>
    {
        protected internal UsersClient(PeerTubeClient client) : base(client, "/api/v1/users") { }

        public async Task<Tokens> TokenAsync(string username, string password)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("client_id", Client.ClientId),
                new KeyValuePair<string, object>("client_secret", Client.ClientSecret),
                new KeyValuePair<string, object>("grant_type", "password"),
                new KeyValuePair<string, object>("response_type", "code"),
                new KeyValuePair<string, object>("username", username),
                new KeyValuePair<string, object>("password", password)
            };

            var tokens = await PostAsync<Tokens>("/token", parameters).Stay();
            Client.AccessToken = tokens.AccessToken;
            Client.RefreshToken = tokens.RefreshToken;

            return tokens;
        }
    }
}