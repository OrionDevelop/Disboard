using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Mastodon.Models;

namespace Disboard.Mastodon.Clients
{
    public class SuggestionsClient : ApiClient<MastodonClient>
    {
        protected internal SuggestionsClient(MastodonClient client) : base(client, "/api/v1/suggestions") { }

        public async Task<List<Account>> ListAsync(long? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);

            return await GetAsync<List<Account>>(parameters: parameters).Stay();
        }

        public async Task DestroyAsync(long id)
        {
            await DeleteAsync($"/{id}").Stay();
        }
    }
}