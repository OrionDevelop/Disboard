using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;

using RootClient = Disboard.Pleroma.PleromaClient;

namespace Disboard.Pleroma.Clients
{
    public class PleromaClient : ApiClient<RootClient>
    {
        protected internal PleromaClient(RootClient client) : base(client, "/api/pleroma") { }

        public async Task<Dictionary<string, string>> EmojiAsync()
        {
            return await GetAsync<Dictionary<string, string>>("/emoji").Stay();
        }

        public async Task FollowImport(IEnumerable<string> ids)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("list", string.Join(" ", ids))
            };

            await PostAsync("/follow_imports", parameters).Stay();
        }
    }
}