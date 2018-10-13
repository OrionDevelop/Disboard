using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Mastodon.Models;

namespace Disboard.Mastodon.Clients.Push
{
    public class SubscriptionClient : ApiClient<MastodonClient>
    {
        protected internal SubscriptionClient(MastodonClient client) : base(client, "/api/v1/push/subscription") { }

        public async Task<PushSubscription> CreateAsync(string endpoint, Keys keys, Alerts alerts)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("subscription[endpoint]", endpoint),
                new KeyValuePair<string, object>("subscription[keys][p256dh]", keys.P256DH),
                new KeyValuePair<string, object>("subscription[key][auth]", keys.Auth),
                new KeyValuePair<string, object>("data[alerts][follow]", alerts.Follow),
                new KeyValuePair<string, object>("data[alerts][favourite]", alerts.Favourite),
                new KeyValuePair<string, object>("data[alerts][reblog]", alerts.Reblog),
                new KeyValuePair<string, object>("data[alerts][mention]", alerts.Mention)
            };

            return await PostAsync<PushSubscription>(parameters: parameters).Stay();
        }

        public async Task<PushSubscription> UpdateAsync(Alerts alerts)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("data[alerts][follow]", alerts.Follow),
                new KeyValuePair<string, object>("data[alerts][favourite]", alerts.Favourite),
                new KeyValuePair<string, object>("data[alerts][reblog]", alerts.Reblog),
                new KeyValuePair<string, object>("data[alerts][mention]", alerts.Mention)
            };

            return await PatchAsync<PushSubscription>(parameters: parameters).Stay();
        }

        public async Task Destroy()
        {
            await DeleteAsync().Stay();
        }

        public async Task<PushSubscription> ShowAsync()
        {
            return await GetAsync<PushSubscription>().Stay();
        }
    }
}