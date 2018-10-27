using Disboard.Clients;
using Disboard.Misskey.Clients.Notes;

namespace Disboard.Misskey.Clients
{
    public class NotesClient : ApiClient<MisskeyClient>
    {
        public FavoritesClient FavoritesClient { get; }
        public PollsClient Polls { get; }
        public ReactionsClient Reactions { get; }

        protected internal NotesClient(MisskeyClient client) : base(client, "/api/notes")
        {
            FavoritesClient = new FavoritesClient(client);
            Polls = new PollsClient(client);
            Reactions = new ReactionsClient(client);
        }
    }
}