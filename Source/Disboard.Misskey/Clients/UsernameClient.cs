using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Models;

namespace Disboard.Misskey.Clients
{
    public class UsernameClient : ApiClient<MisskeyClient>
    {
        protected internal UsernameClient(MisskeyClient client) : base(client, "/api/username") { }

        public async Task<bool> AvailableAsync(string username)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("username", username)};

            var response = await PostAsync<ApiResponse>("/available", parameters);
            return response.Extends["available"].ToObject<bool>();
        }
    }
}