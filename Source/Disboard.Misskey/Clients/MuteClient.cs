using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients
{
    public partial class MuteClient : MisskeyApiClient
    {
        protected internal MuteClient(MisskeyClient client) : base(client, "mute") { }

        public async Task CreateAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};
            await PostAsync("/create", parameters).Stay();
        }

        public async Task DeleteAsync(string userId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};
            await PostAsync("/delete", parameters).Stay();
        }

        public async Task<List<Muting>> ListAsync(int? limit = null, string sinceId = null, string untilId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("sinceId", sinceId);
            parameters.AddIfValidValue("untilId", untilId);

            return await PostAsync<List<Muting>>("/list", parameters).Stay();
        }
    }
}