using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Mastodon.Models;

namespace Disboard.Mastodon.Clients
{
    public class CustomEmojisClient : ApiClient<MastodonClient>
    {
        protected internal CustomEmojisClient(MastodonClient client) : base(client, "/api/v1/custom_emojis") { }

        public async Task<List<Emoji>> ShowAsync()
        {
            return await GetAsync<List<Emoji>>().Stay();
        }
    }
}