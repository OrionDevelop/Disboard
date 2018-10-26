using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients.Following
{
    public class RequestsClient : ApiClient<MisskeyClient>
    {
        protected internal RequestsClient(MisskeyClient client) : base(client, "/api/following/requests") { }

        public async Task AcceptAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};
            await PostAsync("/accept", parameters);
        }

        public async Task<User> CancelAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};
            return await PostAsync<User>("/cancel", parameters);
        }

        public async Task<List<FollowRequest>> ListAsync()
        {
            return await PostAsync<List<FollowRequest>>("/list");
        }

        public async Task RejectAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};
            await PostAsync("/reject", parameters);
        }
    }
}