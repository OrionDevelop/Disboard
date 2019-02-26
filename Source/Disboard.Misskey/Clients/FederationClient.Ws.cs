using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients
{
    public partial class FederationClient
    {
        public async Task<List<Instance>> InstancesWsAsync(bool? blocked = null, bool? notResponding = null, bool? markedAsClosed = null, int? limit = null, int? offset = null, string sort = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("blocked", blocked);
            parameters.AddIfValidValue("notResponding", notResponding);
            parameters.AddIfValidValue("markedAsClosed", markedAsClosed);
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("offset", offset);
            parameters.AddIfValidValue("sort", sort);

            return await SendWsAsync<List<Instance>>("/instances", parameters).Stay();
        }

        public async Task<Instance> ShowInstanceWsAsync(string host)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("host", host) };

            return await SendWsAsync<Instance>("/show-instance", parameters).Stay();
        }
    }
}