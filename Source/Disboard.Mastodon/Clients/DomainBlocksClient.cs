using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Models;

namespace Disboard.Mastodon.Clients
{
    public class DomainBlocksClient : ApiClient<MastodonClient>
    {
        protected internal DomainBlocksClient(MastodonClient client) : base(client, "/api/v1/domain_blocks") { }

        public async Task<Pagenator<string>> ListAsync(long? limit = null, long? sinceId = null, long? maxId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("since_id", sinceId);
            parameters.AddIfValidValue("max_id", maxId);

            return await GetAsync<Pagenator<string>>(parameters: parameters).Stay();
        }

        public async Task CreateAsync(string domain)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("domain", domain)
            };
            await PostAsync(parameters: parameters).Stay();
        }

        public async Task DestroyAsync(string domain)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("domain", domain)
            };
            await DeleteAsync(parameters: parameters).Stay();
        }
    }
}