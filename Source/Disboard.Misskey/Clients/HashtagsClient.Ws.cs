using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients
{
    public partial class HashtagsClient
    {
        public async Task<List<string>> SearchWsAsync(string query, int? limit = null, long? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("query", query)};
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("offset", offset);

            return await SendWsAsync<List<string>>("/search", parameters).Stay();
        }

        public async Task<List<TrendTag>> TrendWsAsync()
        {
            return await SendWsAsync<List<TrendTag>>("/trend").Stay();
        }
    }
}