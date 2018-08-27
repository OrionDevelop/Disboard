using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Mastodon.Models;

namespace Disboard.Mastodon.Clients
{
    public class CustomEmojisClient : ApiClient<MastodonClient>
    {
        internal CustomEmojisClient(MastodonClient client) : base(client, "/api/v1/custom_emojis") { }

        public async Task<List<Emoji>> FetchAsync()
        {
            return await GetAsync<List<Emoji>>().Stay();
        }
    }
}