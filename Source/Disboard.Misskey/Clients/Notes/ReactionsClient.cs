using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Enums;
using Disboard.Misskey.Extensions;

namespace Disboard.Misskey.Clients.Notes
{
    public partial class ReactionsClient : MisskeyApiClient
    {
        protected internal ReactionsClient(MisskeyClient client) : base(client, "notes/reactions") { }

        public async Task CreateAsync(string noteId, Reaction reaction)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("noteId", noteId),
                new KeyValuePair<string, object>("reaction", reaction.ToStr())
            };

            await PostAsync("/create", parameters).Stay();
        }

        public async Task DeleteAsync(string noteId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("noteId", noteId)};

            await PostAsync("/delete", parameters).Stay();
        }
    }
}