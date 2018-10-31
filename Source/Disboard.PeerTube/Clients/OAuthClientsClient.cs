using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.PeerTube.Models;

namespace Disboard.PeerTube.Clients
{
    public class OAuthClientsClient : ApiClient<PeerTubeClient>
    {
        protected internal OAuthClientsClient(PeerTubeClient client) : base(client, "/api/v1/oauth-clients") { }

        public async Task<Client> LocalAsync()
        {
            return await GetAsync<Client>("/local");
        }
    }
}