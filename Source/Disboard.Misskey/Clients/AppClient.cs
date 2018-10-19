using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients
{
    public class AppClient : ApiClient<MisskeyClient>
    {
        protected internal AppClient(MisskeyClient client) : base(client, "/api/app") { }

        public async Task<Application> CreateAsync(string name, string description, string[] permissions, string callbackUrl)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("name", name),
                new KeyValuePair<string, object>("description", description),
                new KeyValuePair<string, object>("callbackUrl", callbackUrl),
                new KeyValuePair<string, object>("permission", permissions)
            };

            var response = await PostAsync<Application>("/create", parameters).Stay();
            Client.ClientSecret = response.Secret;

            return response;
        }

        public async Task<Application> ShowAsync(string appId)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("appId", appId)
            };

            return await PostAsync<Application>("/show", parameters).Stay();
        }
    }
}