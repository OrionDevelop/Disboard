using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients.Users
{
    public partial class ListsClient
    {
        public async Task<List> CreateWsAsync(string title)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("title", title) };

            return await SendWsAsync<List>("/create", parameters).Stay();
        }

        public async Task DeleteWsAsync(string listId)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("listId", listId) };

            await SendWsAsync("/delete", parameters).Stay();
        }

        public async Task<List<List>> ListWsAsync()
        {
            return await SendWsAsync<List<List>>("/list").Stay();
        }

        public async Task PullWsAsync(string listId, string userId)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("listId", listId),
                new KeyValuePair<string, object>("userId", userId)
            };

            await SendWsAsync("/pull", parameters).Stay();
        }

        public async Task PushWsAsync(string listId, string userId)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("listId", listId),
                new KeyValuePair<string, object>("userId", userId)
            };

            await SendWsAsync("/push", parameters).Stay();
        }

        public async Task<List> ShowWsAsync(string listId)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("listId", listId) };

            return await SendWsAsync<List>("/show", parameters).Stay();
        }

        public async Task<List> UpdateWsAsync(string listId, string title)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("listId", listId),
                new KeyValuePair<string, object>("title", title)
            };

            return await SendWsAsync<List>("/update", parameters).Stay();
        }
    }
}