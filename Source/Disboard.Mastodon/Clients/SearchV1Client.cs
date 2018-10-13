using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Mastodon.Models;

namespace Disboard.Mastodon.Clients
{
    public class SearchV1Client : ApiClient<MastodonClient>
    {
        protected internal SearchV1Client(MastodonClient client) : base(client, "/api/v1/search") { }

        public async Task<SearchV1> SearchAsync(string q, bool? resolve = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("q", q)
            };
            parameters.AddIfValidValue("resolve", resolve);

            return await GetAsync<SearchV1>(parameters: parameters).Stay();
        }
    }
}