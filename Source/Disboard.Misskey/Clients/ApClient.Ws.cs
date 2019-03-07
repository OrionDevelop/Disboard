using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;

using Newtonsoft.Json.Linq;

namespace Disboard.Misskey.Clients
{
    public partial class ApClient
    {
        public async Task<JObject> ShowWsAsync(string uri)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("uri", uri) };
            return await SendWsAsync<JObject>("/show", parameters).Stay();
        }
    }
}