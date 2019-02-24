using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients.Notes
{
    public partial class PollsClient
    {
        public async Task<List<Note>> RecommendationWsAsync(int? limit = null, int? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("offset", offset);

            return await SendWsAsync<List<Note>>("/recommendation", parameters).Stay();
        }

        public async Task VoteWsAsync(string noteId, int choice)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("noteId", noteId),
                new KeyValuePair<string, object>("choice", choice)
            };

            await SendWsAsync("/vote", parameters).Stay();
        }
    }
}