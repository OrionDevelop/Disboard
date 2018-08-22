using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Mastodon.Enums;
using Disboard.Mastodon.Models;

namespace Disboard.Mastodon.Clients
{
    public class AppsClient : ApiClient<MastodonClient>
    {
        internal AppsClient(MastodonClient client) : base(client, "/api/v1/apps") { }

        public async Task<Application> RegisterAsync(string clientName, string redirectUris, AccessScope scopes, string website = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("client_name", clientName),
                new KeyValuePair<string, object>("redirect_uris", redirectUris),
                new KeyValuePair<string, object>("scopes", scopes.ToString().ToLower().Replace(", ", ""))
            };
            if (!string.IsNullOrWhiteSpace(website))
                parameters.Add(new KeyValuePair<string, object>("website", website));

            return await PostAsync<Application>("", parameters).Stay();
        }
    }
}