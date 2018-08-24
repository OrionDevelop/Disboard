using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Mastodon.Models;

namespace Disboard.Mastodon.Clients
{
    public class InstanceClient : ApiClient<MastodonClient>
    {
        internal InstanceClient(MastodonClient client) : base(client, "/api/v1/instance") { }

        public async Task<Instance> FetchAsync()
        {
            return await GetAsync<Instance>("").Stay();
        }
    }
}