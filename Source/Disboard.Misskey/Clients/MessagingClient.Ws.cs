using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients
{
    public partial class MessagingClient
    {
        public async Task<List<Message>> HistoryWsAsync(int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);

            return await SendWsAsync<List<Message>>("/history", parameters).Stay();
        }

        public async Task<List<Message>> MessagesWsAsync(string userId, bool? markAsRead = null, int? limit = null, string sinceId = null, string untilId = null)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};
            parameters.AddIfValidValue("markAsRead", markAsRead);
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("sinceId", sinceId);
            parameters.AddIfValidValue("untilId", untilId);

            return await SendWsAsync<List<Message>>("/messages", parameters).Stay();
        }
    }
}