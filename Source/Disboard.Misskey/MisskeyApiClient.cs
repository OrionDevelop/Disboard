using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;

namespace Disboard.Misskey
{
    public class MisskeyApiClient : ApiClient<MisskeyClient>
    {
        private readonly string _base;

        protected MisskeyApiClient(MisskeyClient client, string @base) : base(client, $"/api/{@base}")
        {
            _base = @base;
        }

        protected async Task<T> SendWsAsync<T>(string endpoint = null, List<KeyValuePair<string, object>> parameters = null)
        {
            return await Client.SendWsAsync<T>(_base + endpoint, parameters).Stay();
        }

        protected async Task SendWsAsync(string endpoint = null, List<KeyValuePair<string, object>> parameters = null)
        {
            await Client.SendWsAsync(_base + endpoint, parameters).Stay();
        }
    }
}