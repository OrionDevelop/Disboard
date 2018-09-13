using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Mastodon.Models;

namespace Disboard.Mastodon.Clients
{
    public class ReportsClient : ApiClient<MastodonClient>
    {
        internal ReportsClient(MastodonClient client) : base(client, "/api/v1/reports") { }

        public async Task<List<Report>> ListAsync()
        {
            return await GetAsync<List<Report>>().Stay();
        }

        public async Task<Report> CreateAsync(long accountId, string comment, bool forward, List<long> statusIds)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("account_id", accountId),
                new KeyValuePair<string, object>("comment", comment),
                new KeyValuePair<string, object>("forward", forward.ToString().ToLower())
            };
            statusIds.ForEach(w => parameters.Add(new KeyValuePair<string, object>("status_ids[]", w)));

            return await PostAsync<Report>(parameters: parameters).Stay();
        }
    }
}