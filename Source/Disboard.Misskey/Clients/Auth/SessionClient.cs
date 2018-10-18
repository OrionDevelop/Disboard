using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients.Auth
{
    public class SessionClient : ApiClient<MisskeyClient>
    {
        internal SessionClient(MisskeyClient client) : base(client, "/api/auth/session") { }

        public async Task<Session> GenerateAsync()
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("appSecret", Client.ClientSecret)
            };

            return await PostAsync<Session>("/generate", parameters).Stay();
        }

        public async Task<Credential> UserKeyAsync(string token)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("appSecret", Client.ClientSecret),
                new KeyValuePair<string, object>("token", token)
            };

            var response = await PostAsync<Credential>("/userkey", parameters).Stay();
            Client.AccessToken = response.AccessToken;

            return response;
        }
    }
}