using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Mastodon.Models;

namespace Disboard.Mastodon.Clients
{
    public class SearchV1Client : ApiClient<MastodonClient>
    {
        internal SearchV1Client(MastodonClient client) : base(client, "/api/v1/search") { }

        public async Task<Search> SearchAsync(string q, bool? resolve = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("q", q)
            };
            parameters.AddIfValidValue("resolve", resolve);

            return await GetAsync<Search>(parameters: parameters).Stay();
        }
    }
}