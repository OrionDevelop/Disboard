using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Mastodon.Models;
using Disboard.Models;

namespace Disboard.Mastodon.Clients
{
    public class FollowRequestsClient : ApiClient<MastodonClient>
    {
        protected internal FollowRequestsClient(MastodonClient client) : base(client, "/api/v1/follow_requests") { }

        public async Task AuthorizeAsync(long id)
        {
            await PostAsync($"/{id}/authorize").Stay();
        }

        public async Task RejectAsync(long id)
        {
            await PostAsync($"/{id}/reject").Stay();
        }

        public async Task<Pagenator<Account>> ListAsync(long? limit = null, long? sinceId = null, long? maxId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("since_id", sinceId);
            parameters.AddIfValidValue("max_id", maxId);

            return await GetAsync<Pagenator<Account>>(parameters: parameters).Stay();
        }
    }
}