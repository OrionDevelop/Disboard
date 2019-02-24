using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Mastodon.Models;

namespace Disboard.Mastodon.Clients
{
    public class ScheduledStatusesClient : ApiClient<MastodonClient>
    {
        protected internal ScheduledStatusesClient(MastodonClient client) : base(client, "/api/v1/scheduled_statuses") { }

        public async Task<List<ScheduledStatus>> ListAsync()
        {
            return await GetAsync<List<ScheduledStatus>>().Stay();
        }

        public async Task<ScheduledStatus> ShowAsync(long id)
        {
            return await GetAsync<ScheduledStatus>($"/{id}").Stay();
        }

        public async Task<ScheduledStatus> UpdateAsync(long id, DateTime scheduledAt)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("scheduled_at", scheduledAt.ToString("O")) }; // ISO 8601}

            return await PutAsync<ScheduledStatus>($"/{id}", parameters).Stay();
        }

        public async Task DeleteAsync(long id)
        {
            await DeleteAsync($"/{id}").Stay();
        }
    }
}