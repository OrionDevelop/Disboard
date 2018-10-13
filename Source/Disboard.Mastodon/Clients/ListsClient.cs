using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Mastodon.Models;
using Disboard.Models;

namespace Disboard.Mastodon.Clients
{
    public class ListsClient : ApiClient<MastodonClient>
    {
        protected internal ListsClient(MastodonClient client) : base(client, "/api/v1/lists") { }

        public async Task<Pagenator<Account>> AccountsAsync(long id, long? limit = null, long? sinceId = null, long? maxId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("since_id", sinceId);
            parameters.AddIfValidValue("max_id", maxId);

            return await GetAsync<Pagenator<Account>>($"/{id}/accounts", parameters).Stay();
        }

        public async Task<Account> AddAccountAsync(long id, List<long> accountIds)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            accountIds.ForEach(w => parameters.Add(new KeyValuePair<string, object>("account_ids[]", w)));

            return await PostAsync<Account>($"/{id}/accounts", parameters).Stay();
        }

        public async Task<Account> RemoveAccountAsync(long id, List<long> accountIds)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            accountIds.ForEach(w => parameters.Add(new KeyValuePair<string, object>("account_ids[]", w)));

            return await DeleteAsync<Account>($"/{id}/accounts", parameters).Stay();
        }

        public async Task<List<List>> ListAsync()
        {
            return await GetAsync<List<List>>().Stay();
        }

        public async Task<List> ShowAsync(long id)
        {
            return await GetAsync<List>($"/{id}").Stay();
        }

        public async Task<List> CreateAsync(string title)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("title", title)
            };

            return await PostAsync<List>(parameters: parameters).Stay();
        }

        public async Task<List> UpdateAsync(long id, string title)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("title", title)
            };

            return await PatchAsync<List>($"/{id}", parameters).Stay();
        }

        public async Task DestroyAsync(long id)
        {
            await DeleteAsync($"/{id}").Stay();
        }
    }
}