using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Mastodon.Models;
using Disboard.Models;

namespace Disboard.Mastodon.Clients
{
    public class ConversationsClient : ApiClient<MastodonClient>
    {
        protected internal ConversationsClient(MastodonClient client) : base(client, "/api/v1/conversations") { }

        public async Task<Pagenator<Conversation>> ListAsync(int? limit = null, long? sinceId = null, long? minId = null, long? maxId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("since_id", sinceId);
            parameters.AddIfValidValue("min_id", minId);
            parameters.AddIfValidValue("max_id", maxId);

            return await GetAsync<Pagenator<Conversation>>(parameters: parameters).Stay();
        }

        public async Task<Conversation> ReadAsync(long id)
        {
            return await PostAsync<Conversation>($"/{id}/read").Stay();
        }

        public async Task DestroyAsync(long id)
        {
            await DeleteAsync($"/{id}").Stay();
        }
    }
}