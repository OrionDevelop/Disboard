using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Mastodon.Models;
using Disboard.Models;

namespace Disboard.Mastodon.Clients
{
    public class EndorsementsClient : ApiClient<MastodonClient>
    {
        internal EndorsementsClient(MastodonClient client) : base(client, "/api/v1/endorsements") { }

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