using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Mastodon.Enums;
using Disboard.Mastodon.Models;
using Disboard.Utils;

namespace Disboard.Mastodon.Clients
{
    public class NotificationsClient : ApiClient<MastodonClient>
    {
        internal NotificationsClient(MastodonClient client) : base(client, "/api/v1/notifications") { }

        public async Task<List<Notification>> ListAsync(long? maxId = null, long? sinceId = null, int? limit = null, NotificationType? excludeTypes = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("max_id", maxId);
            parameters.AddIfValidValue("since_id", sinceId);
            parameters.AddIfValidValue("limit", limit);
            if (excludeTypes.HasValue)
                foreach (var excludeType in EnumSeparator.Separate(excludeTypes))
                    parameters.Add(new KeyValuePair<string, object>("exclude_types[]", excludeType));

            return await GetAsync<List<Notification>>("", parameters).Stay();
        }

        public async Task<Notification> ShowAsync(long id)
        {
            return await GetAsync<Notification>($"/{id}").Stay();
        }

        public async Task ClearAsync()
        {
            await PostAsync("/clear").Stay();
        }

        public async Task DismissAsync(long id)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("id", id)};
            await PostAsync("/dismiss", parameters).Stay();
        }
    }
}