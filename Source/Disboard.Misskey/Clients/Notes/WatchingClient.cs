using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;

namespace Disboard.Misskey.Clients.Notes
{
    public partial class WatchingClient : MisskeyApiClient
    {
        protected internal WatchingClient(MisskeyClient client) : base(client, "notes/watching") { }

        public async Task CreateAsync(string noteId)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("noteId", noteId) };

            await PostAsync("/create", parameters).Stay();
        }

        public async Task DeleteAsync(string noteId)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("noteId", noteId) };

            await PostAsync("/delete", parameters).Stay();
        }
    }
}