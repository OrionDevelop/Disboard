using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients
{
    public class FollowingClient : ApiClient<MisskeyClient>
    {
        protected internal FollowingClient(MisskeyClient client) : base(client, "/api/following") { }

        public async Task<User> CreateAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};

            return await PostAsync<User>("/create", parameters).Stay();
        }

        public async Task<User> DeleteAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};

            return await PostAsync<User>("/delete", parameters).Stay();
        }

        public async Task StalkAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};

            await PostAsync<User>("/stalk", parameters).Stay();
        }

        public async Task UnstalkAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};

            await PostAsync<User>("/unstalk", parameters).Stay();
        }
    }
}