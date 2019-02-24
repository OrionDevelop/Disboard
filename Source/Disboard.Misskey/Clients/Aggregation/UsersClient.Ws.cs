using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients.Aggregation
{
    public partial class UsersClient
    {
        [Obsolete]
        public async Task<List<PostAggregation>> ActivityWsAsync(string userId, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("userId", userId) };
            parameters.AddIfValidValue("limit", limit);

            return await SendWsAsync<List<PostAggregation>>("/activity", parameters).Stay();
        }

        [Obsolete]
        public async Task<List<CountAggregation>> FollowersWsAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("userId", userId) };

            return await SendWsAsync<List<CountAggregation>>("/followers", parameters).Stay();
        }

        [Obsolete]
        public async Task<List<CountAggregation>> FollowingWsAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("userId", userId) };

            return await SendWsAsync<List<CountAggregation>>("/following", parameters).Stay();
        }

        [Obsolete]
        public async Task<List<PostAggregation>> PostWsAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("userId", userId) };

            return await SendWsAsync<List<PostAggregation>>("/post", parameters).Stay();
        }

        [Obsolete]
        public async Task<List<CountAggregation>> ReactionWsAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("userId", userId) };

            return await SendWsAsync<List<CountAggregation>>("/reaction", parameters).Stay();
        }
    }
}