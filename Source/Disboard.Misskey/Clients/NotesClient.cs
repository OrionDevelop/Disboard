using Disboard.Clients;
using Disboard.Misskey.Clients.Notes;

namespace Disboard.Misskey.Clients
{
    public class NotesClient : ApiClient<MisskeyClient>
    {
        public FavoritesClient FavoritesClient { get; }

        protected internal NotesClient(MisskeyClient client) : base(client, "/api/notes")
        {
            FavoritesClient = new FavoritesClient(client);
        }
    }
}