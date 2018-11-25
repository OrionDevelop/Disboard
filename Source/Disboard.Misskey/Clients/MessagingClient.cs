using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Clients.Messaging;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients
{
    public partial class MessagingClient : MisskeyApiClient
    {
        public MessagesClient Messages { get; }

        protected internal MessagingClient(MisskeyClient client) : base(client, "messaging")
        {
            Messages = new MessagesClient(client);
        }

        public async Task<List<Message>> HistoryAsync(int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);

            return await PostAsync<List<Message>>("/history", parameters).Stay();
        }

        public async Task<List<Message>> MessagesAsync(string userId, bool? markAsRead = null, int? limit = null, string sinceId = null, string untilId = null)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};
            parameters.AddIfValidValue("markAsRead", markAsRead);
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("sinceId", sinceId);
            parameters.AddIfValidValue("untilId", untilId);

            return await PostAsync<List<Message>>("/messages", parameters).Stay();
        }
    }
}