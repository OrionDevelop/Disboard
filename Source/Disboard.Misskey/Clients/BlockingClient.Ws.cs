using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients
{
    public partial class BlockingClient
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

        public async Task<List<Blocking>> ListWsAsync(int? limit = null, string sinceId = null, string untilId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("sinceId", sinceId);
            parameters.AddIfValidValue("untilId", untilId);

            return await SendWsAsync<List<Blocking>>("/list", parameters).Stay();
        }
    }
}