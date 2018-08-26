using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;

namespace Disboard.Mastodon.Clients
{
    public class BlocksClient : ApiClient<MastodonClient>
    {
        internal BlocksClient(MastodonClient client) : base(client, "/api/v1/blocks") { }

        public async Task<string> ListAsync(long? limit = null, long? sinceId = null, long? maxId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("since_id", sinceId);
            parameters.AddIfValidValue("max_id", maxId);

            return await GetAsync("", parameters).Stay();
        }
    }
}