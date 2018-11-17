using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients
{
    public partial class AppClient
    {
        // NOTE: REMOVED CreateWsAsync(string, string, string[], string);

        public async Task<App> ShowWsAsync(string appId)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("appId", appId)
            };

            return await SendWsAsync<App>("/show", parameters).Stay();
        }
    }
}