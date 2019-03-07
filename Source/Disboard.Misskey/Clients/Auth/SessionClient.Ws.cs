using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Models;

namespace Disboard.Misskey.Clients.Auth
{
    public partial class SessionClient
    {
        // NOTE: REMOVED GenerateWsAsync();

        public async Task<ApiResponse> ShowWsAsync(string token)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("token", token) };

            return await SendWsAsync<ApiResponse>("/show", parameters).Stay();
        }

        // NOTE: REMOVED UserKeyWsAsync(string);
    }
}