using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Enums;
using Disboard.Misskey.Extensions;

namespace Disboard.Misskey.Clients.Notes
{
    public partial class ReactionsClient
    {
        public async Task CreateWsAsync(string noteId, Reaction reaction)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("noteId", noteId),
                new KeyValuePair<string, object>("reaction", reaction.ToStr())
            };

            await SendWsAsync("/create", parameters).Stay();
        }

        public async Task DeleteWsAsync(string noteId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("noteId", noteId)};

            await SendWsAsync("/delete", parameters).Stay();
        }
    }
}