using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients
{
    public partial class HashtagsClient
    {
        public async Task<List<HashtagWithStats>> ListWsAsync(string sort, int? limit = null, bool? attachedToUserOnly = null, bool? attachedToLocalUserOnly = null, bool? attachedToRemoteUserOnly = false)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("sort", sort) };
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("attachedToUserOnly", attachedToUserOnly);
            parameters.AddIfValidValue("attachedToLocalUserOnly", attachedToLocalUserOnly);
            parameters.AddIfValidValue("attachedToRemoteUserOnly", attachedToRemoteUserOnly);

            return await SendWsAsync<List<HashtagWithStats>>("/list", parameters).Stay();
        }

        public async Task<List<string>> SearchWsAsync(string query, int? limit = null, long? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("query", query) };
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("offset", offset);

            return await SendWsAsync<List<string>>("/search", parameters).Stay();
        }

        public async Task<List<TrendTag>> TrendWsAsync()
        {
            return await SendWsAsync<List<TrendTag>>("/trend").Stay();
        }

        public async Task<List<User>> UsersWsAsync(string tag, string sort, int? limit = null, string state = null, string origin = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("tag", tag),
                new KeyValuePair<string, object>("sort", sort)
            };
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("state", state);
            parameters.AddIfValidValue("origin", origin);

            return await SendWsAsync<List<User>>("/users", parameters).Stay();
        }
    }
}