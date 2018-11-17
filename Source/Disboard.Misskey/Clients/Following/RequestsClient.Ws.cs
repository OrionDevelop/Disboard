using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients.Following
{
    public partial class RequestsClient
    {
        public async Task AcceptWsAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};
            await SendWsAsync("/accept", parameters).Stay();
        }

        public async Task<User> CancelWsAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};
            return await SendWsAsync<User>("/cancel", parameters).Stay();
        }

        public async Task<List<FollowRequest>> ListWsAsync()
        {
            return await SendWsAsync<List<FollowRequest>>("/list").Stay();
        }

        public async Task RejectWsAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};
            await SendWsAsync("/reject", parameters).Stay();
        }
    }
}