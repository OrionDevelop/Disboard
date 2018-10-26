using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients
{
    public class HashtagsClient : ApiClient<MisskeyClient>
    {
        protected internal HashtagsClient(MisskeyClient client) : base(client, "/api/hashtags") { }

        public async Task<List<string>> SearchAsync(string query, int? limit = null, long? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("query", query)};
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("offset", offset);

            return await PostAsync<List<string>>("/search", parameters);
        }

        public async Task<List<TrendTag>> TrendAsync()
        {
            return await PostAsync<List<TrendTag>>("/trend");
        }
    }
}