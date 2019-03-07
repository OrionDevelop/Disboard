using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;

using Newtonsoft.Json.Linq;

namespace Disboard.Misskey.Clients
{
    public partial class ApClient : MisskeyApiClient
    {
        protected internal ApClient(MisskeyClient client) : base(client, "ap") { }

        // いろんなオブジェクト帰ってくるっぽいので許してくれって感じ
        public async Task<JObject> ShowAsync(string uri)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("uri", uri) };
            return await PostAsync<JObject>("/show", parameters).Stay();
        }
    }
}