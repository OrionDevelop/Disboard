using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;

namespace Disboard.Misskey.Clients.Notes
{
    public class FavoritesClient : ApiClient<MisskeyClient>
    {
        protected internal FavoritesClient(MisskeyClient client) : base(client, "/api/notes/favorites") { }

        public async Task CreateAsync(string noteId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("noteId", noteId)};

            await PostAsync("/create", parameters);
        }

        public async Task DeleteAsync(string noteId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("noteId", noteId)};

            await PostAsync("/delete", parameters);
        }
    }
}