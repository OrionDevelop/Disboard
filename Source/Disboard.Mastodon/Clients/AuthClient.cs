using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Mastodon.Enums;
using Disboard.Mastodon.Models;

namespace Disboard.Mastodon.Clients
{
    public class AuthClient : ApiClient<MastodonClient>
    {
        protected internal AuthClient(MastodonClient client) : base(client, "/oauth") { }

        public string AuthorizeUrl(string redirectUri, AccessScope scopes)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("scope", scopes.ToString().ToLower().Replace(",", "")),
                new KeyValuePair<string, object>("response_type", "code"),
                new KeyValuePair<string, object>("redirect_uri", redirectUri),
                new KeyValuePair<string, object>("client_id", Client.ClientId)
            };
            return $"https://{Client.Domain}/oauth/authorize?{string.Join("&", AppClient.AsUrlParameter(parameters))}";
        }

        public async Task<Tokens> AccessTokenAsync(string redirectUri, string code)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("client_id", Client.ClientId),
                new KeyValuePair<string, object>("client_secret", Client.ClientSecret),
                new KeyValuePair<string, object>("grant_type", "authorization_code"),
                new KeyValuePair<string, object>("code", code),
                new KeyValuePair<string, object>("redirect_uri", redirectUri)
            };
            var response = await PostAsync<Tokens>("/token", parameters).Stay();
            Client.AccessToken = response.AccessToken;

            return response;
        }
    }
}