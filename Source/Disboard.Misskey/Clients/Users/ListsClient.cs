using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients.Users
{
    public class ListsClient : ApiClient<MisskeyClient>
    {
        protected internal ListsClient(MisskeyClient client) : base(client, "/api/users/lists") { }

        public async Task<List> CreateAsync(string title)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("title", title)};

            return await PostAsync<List>("/create", parameters);
        }

        public async Task DeleteAsync(string listId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("listId", listId)};

            await PostAsync("/delete", parameters);
        }

        public async Task<List<List>> ListAsync()
        {
            return await PostAsync<List<List>>("/list");
        }

        public async Task PushAsync(string listId, string userId)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("listId", listId),
                new KeyValuePair<string, object>("userId", userId)
            };

            await PostAsync("/push", parameters);
        }

        public async Task<List> ShowAsync(string listId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("listId", listId)};

            return await PostAsync<List>("/show", parameters);
        }

        public async Task<List> UpdateAsync(string listId, string title)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("listId", listId),
                new KeyValuePair<string, object>("title", title)
            };

            return await PostAsync<List>("/update", parameters);
        }
    }
}