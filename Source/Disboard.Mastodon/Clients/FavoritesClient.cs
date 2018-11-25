using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Mastodon.Models;
using Disboard.Models;

namespace Disboard.Mastodon.Clients
{
    public class FavoritesClient : ApiClient<MastodonClient>
    {
        protected internal FavoritesClient(MastodonClient client) : base(client, "/api/v1/favourites") { }

        public async Task<Pagenator<Status>> ListAsync(long? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);

            return await GetAsync<Pagenator<Status>>(parameters: parameters).Stay();
        }
    }
}