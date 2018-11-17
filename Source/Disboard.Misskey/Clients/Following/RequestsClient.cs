using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients.Following
{
    public partial class RequestsClient : MisskeyApiClient
    {
        protected internal RequestsClient(MisskeyClient client) : base(client, "following/requests") { }

        public async Task AcceptAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};
            await PostAsync("/accept", parameters).Stay();
        }

        public async Task<User> CancelAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};
            return await PostAsync<User>("/cancel", parameters).Stay();
        }

        public async Task<List<FollowRequest>> ListAsync()
        {
            return await PostAsync<List<FollowRequest>>("/list").Stay();
        }

        public async Task RejectAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};
            await PostAsync("/reject", parameters).Stay();
        }
    }
}