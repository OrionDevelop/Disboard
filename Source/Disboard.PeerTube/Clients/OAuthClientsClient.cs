using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.PeerTube.Models;

namespace Disboard.PeerTube.Clients
{
    public class OAuthClientsClient : ApiClient<PeerTubeClient>
    {
        protected internal OAuthClientsClient(PeerTubeClient client) : base(client, "/api/v1/oauth-clients") { }

        public async Task<Client> LocalAsync()
        {
            var client = await GetAsync<Client>("/local").Stay();
            Client.ClientId = client.ClientId;
            Client.ClientSecret = client.ClientSecret;

            return client;
        }
    }
}