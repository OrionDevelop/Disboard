using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients
{
    public partial class BlockingClient : MisskeyApiClient
    {
        protected internal BlockingClient(MisskeyClient client) : base(client, "blocking") { }

        public async Task<User> CreateAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};

            return await PostAsync<User>("/create", parameters).Stay();
        }

        public async Task<User> DeleteAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};

            return await PostAsync<User>("/delete", parameters).Stay();
        }

        public async Task<List<Blocking>> ListAsync(int? limit = null, string sinceId = null, string untilId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("sinceId", sinceId);
            parameters.AddIfValidValue("untilId", untilId);

            return await PostAsync<List<Blocking>>("/list", parameters).Stay();
        }
    }
}