using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;

namespace Disboard.Misskey.Clients.Notes
{
    public partial class FavoritesClient : MisskeyApiClient
    {
        protected internal FavoritesClient(MisskeyClient client) : base(client, "notes/favorites") { }

        public async Task CreateAsync(string noteId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("noteId", noteId)};

            await PostAsync("/create", parameters).Stay();
        }

        public async Task DeleteAsync(string noteId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("noteId", noteId)};

            await PostAsync("/delete", parameters).Stay();
        }
    }
}