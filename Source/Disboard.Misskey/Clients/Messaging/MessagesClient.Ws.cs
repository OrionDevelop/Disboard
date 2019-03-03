using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients.Messaging
{
    public partial class MessagesClient
    {
        public async Task<Message> CreateWsAsync(string userId, string text = null, string fileId = null)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("userId", userId) };
            parameters.AddIfValidValue("text", text);
            parameters.AddIfValidValue("fileId", fileId);

            return await SendWsAsync<Message>("/create", parameters).Stay();
        }

        public async Task DeleteWsAsync(string messageId)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("messageId", messageId) };

            await SendWsAsync("/delete", parameters).Stay();
        }

        public async Task ReadWsAsync(string messageId)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("messageId", messageId) };

            await SendWsAsync("/read", parameters).Stay();
        }
    }
}