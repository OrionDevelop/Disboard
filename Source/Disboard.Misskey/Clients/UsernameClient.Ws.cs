using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Models;

namespace Disboard.Misskey.Clients
{
    public partial class UsernameClient
    {
        public async Task<bool> AvailableWsAsync(string username)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("username", username)};

            var response = await SendWsAsync<ApiResponse>("/available", parameters).Stay();
            return response.Extends["available"].ToObject<bool>();
        }
    }
}