using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients.Notes
{
    public partial class PollsClient : MisskeyApiClient
    {
        protected internal PollsClient(MisskeyClient client) : base(client, "notes/polls") { }

        public async Task<List<Note>> RecommendationAsync(int? limit = null, int? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("offset", offset);

            return await PostAsync<List<Note>>("/recommendation", parameters).Stay();
        }

        public async Task VoteAsync(string noteId, int choice)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("noteId", noteId),
                new KeyValuePair<string, object>("choice", choice)
            };

            await PostAsync("/vote", parameters).Stay();
        }
    }
}