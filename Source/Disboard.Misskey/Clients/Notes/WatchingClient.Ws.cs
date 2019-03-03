using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;

namespace Disboard.Misskey.Clients.Notes
{
    public partial class WatchingClient
    {
        public async Task CreateWsAsync(string noteId)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("noteId", noteId) };

            await SendWsAsync("/create", parameters).Stay();
        }

        public async Task DeleteWsAsync(string noteId)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("noteId", noteId) };

            await SendWsAsync("/delete", parameters).Stay();
        }
    }
}