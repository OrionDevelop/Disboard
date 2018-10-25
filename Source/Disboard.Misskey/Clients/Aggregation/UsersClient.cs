using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients.Aggregation
{
    public class UsersClient : ApiClient<MisskeyClient>
    {
        protected internal UsersClient(MisskeyClient client) : base(client, "/api/aggregation/users") { }

        public async Task<List<PostAggregation>> ActivityAsync(string userId, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};
            parameters.AddIfValidValue("limit", limit);

            return await PostAsync<List<PostAggregation>>("/activity", parameters).Stay();
        }

        public async Task<List<CountAggregation>> FollowersAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};

            return await PostAsync<List<CountAggregation>>("/followers", parameters).Stay();
        }

        public async Task<List<CountAggregation>> FollowingAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};

            return await PostAsync<List<CountAggregation>>("/following", parameters).Stay();
        }

        public async Task<List<PostAggregation>> PostAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};

            return await PostAsync<List<PostAggregation>>("/post", parameters).Stay();
        }

        public async Task<List<CountAggregation>> ReactionAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};

            return await PostAsync<List<CountAggregation>>("/reaction", parameters).Stay();
        }
    }
}