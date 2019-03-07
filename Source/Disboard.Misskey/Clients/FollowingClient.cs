using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Clients.Following;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients
{
    public partial class FollowingClient : MisskeyApiClient
    {
        public RequestsClient Requests { get; }

        protected internal FollowingClient(MisskeyClient client) : base(client, "following")
        {
            Requests = new RequestsClient(client);
        }

        public async Task<User> CreateAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("userId", userId) };

            return await PostAsync<User>("/create", parameters).Stay();
        }

        public async Task<User> DeleteAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("userId", userId) };

            return await PostAsync<User>("/delete", parameters).Stay();
        }

        [Obsolete]
        public async Task StalkAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("userId", userId) };

            await PostAsync<User>("/stalk", parameters).Stay();
        }

        [Obsolete]
        public async Task UnstalkAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("userId", userId) };

            await PostAsync<User>("/unstalk", parameters).Stay();
        }
    }
}