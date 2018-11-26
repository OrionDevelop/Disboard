using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Models;
using Disboard.PeerTube.Models;

namespace Disboard.PeerTube.Clients
{
    public class AccountsClient : ApiClient<PeerTubeClient>
    {
        protected internal AccountsClient(PeerTubeClient client) : base(client, "/api/v1/accounts") { }

        public async Task<Account> FindByNameAsync(string name, string sort = null, long? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("sort", sort);
            parameters.AddIfValidValue("offset", offset);

            return await GetAsync<Account>($"/{name}", parameters).Stay();
        }

        public async Task<List<ApiResponse>> VideosAsync(string name)
        {
            return await GetAsync<List<ApiResponse>>($"/{name}/videos").Stay();
        }
    }
}