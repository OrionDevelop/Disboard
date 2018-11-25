using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients
{
    public partial class FollowingClient
    {
        public async Task<User> CreateWsAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};

            return await SendWsAsync<User>("/create", parameters).Stay();
        }

        public async Task<User> DeleteWsAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};

            return await SendWsAsync<User>("/delete", parameters).Stay();
        }

        public async Task StalkWsAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};

            await SendWsAsync<User>("/stalk", parameters).Stay();
        }

        public async Task UnstalkWsAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};

            await SendWsAsync<User>("/unstalk", parameters).Stay();
        }
    }
}