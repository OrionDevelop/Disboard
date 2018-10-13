using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Mastodon.Models;

namespace Disboard.Mastodon.Clients
{
    public class SearchV2Client : ApiClient<MastodonClient>
    {
        protected internal SearchV2Client(MastodonClient client) : base(client, "/api/v2/search") { }

        public async Task<SearchV2> SearchAsync(string q, bool? resolve = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("q", q)
            };
            parameters.AddIfValidValue("resolve", resolve);

            return await GetAsync<SearchV2>(parameters: parameters).Stay();
        }
    }
}