using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Mastodon.Enums;
using Disboard.Mastodon.Models;

namespace Disboard.Mastodon.Clients
{
    public class AppsClient : ApiClient<MastodonClient>
    {
        protected internal AppsClient(MastodonClient client) : base(client, "/api/v1/apps") { }

        public async Task<Application> RegisterAsync(string clientName, string redirectUris, AccessScope scopes, string website = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("client_name", clientName),
                new KeyValuePair<string, object>("redirect_uris", redirectUris),
                new KeyValuePair<string, object>("scopes", scopes.ToString().ToLower().Replace(",", ""))
            };
            parameters.AddIfValidValue("website", website);

            var response = await PostAsync<Application>(parameters: parameters).Stay();
            Client.ClientId = response.ClientId;
            Client.ClientSecret = response.ClientSecret;

            return response;
        }

        public async Task<Application> VerifyCredentialsAsync()
        {
            return await GetAsync<Application>("/verify_credentials").Stay();
        }
    }
}