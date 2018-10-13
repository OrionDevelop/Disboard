using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Mastodon.Models;

namespace Disboard.Mastodon.Clients
{
    public class FollowsClient : ApiClient<MastodonClient>
    {
        protected internal FollowsClient(MastodonClient client) : base(client, "/api/v1/follows") { }

        public async Task<Account> RemoteAsync(string uri)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("uri", uri)
            };

            return await PostAsync<Account>(parameters: parameters).Stay();
        }
    }
}