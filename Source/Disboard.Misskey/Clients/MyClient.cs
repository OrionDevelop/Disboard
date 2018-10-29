using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients
{
    public class MyClient : ApiClient<MisskeyClient>
    {
        protected internal MyClient(MisskeyClient client) : base(client, "/api/my") { }

        public async Task<List<App>> AppsAsync(int? limit = null, int? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("offset", offset);

            return await PostAsync<List<App>>("/apps", parameters).Stay();
        }
    }
}