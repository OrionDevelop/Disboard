using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Clients.Charts;
using Disboard.Misskey.Models;
using Disboard.Models;

namespace Disboard.Misskey.Clients
{
    public partial class ChartsClient : MisskeyApiClient
    {
        public UserClient User { get; }

        protected internal ChartsClient(MisskeyClient client) : base(client, "charts")
        {
            User = new UserClient(client);
        }

        public async Task<ChartLocation<ChartCountData>> ActiveUsersAsync(string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("span", span) };
            parameters.AddIfValidValue("limit", limit);

            return await PostAsync<ChartLocation<ChartCountData>>("/active-users", parameters);
        }

        public async Task<ChartLocation<ChartDriveData1<IEnumerable<long>>>> DriveAsync(string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("span", span) };
            parameters.AddIfValidValue("limit", limit);

            return await PostAsync<ChartLocation<ChartDriveData1<IEnumerable<long>>>>("/drive", parameters).Stay();
        }

        public async Task<ChartBasicData<IEnumerable<long>>> FederationAsync(string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("span", span) };
            parameters.AddIfValidValue("limit", limit);

            var response = await PostAsync<ApiResponse>("/federation", parameters).Stay();
            return response.Extends["instance"].ToObject<ChartBasicData<IEnumerable<long>>>();
        }

        public async Task<ChartLocation<ChartCountData>> HashtagAsync(string tag, string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("tag", tag),
                new KeyValuePair<string, object>("span", span)
            };
            parameters.AddIfValidValue("limit", limit);

            return await PostAsync<ChartLocation<ChartCountData>>("/hashtag", parameters).Stay();
        }

        public async Task<ChartInstanceData> InstanceAsync(string host, string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("host", host),
                new KeyValuePair<string, object>("span", span)
            };
            parameters.AddIfValidValue("limit", limit);

            return await PostAsync<ChartInstanceData>("/instance", parameters).Stay();
        }

        public async Task<ChartNetworkData<IEnumerable<long>>> NetworkAsync(string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("span", span) };
            parameters.AddIfValidValue("limit", limit);

            return await PostAsync<ChartNetworkData<IEnumerable<long>>>("/network", parameters).Stay();
        }

        public async Task<ChartLocation<ChartNoteData<IEnumerable<long>>>> NoteAsync(string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("span", span) };
            parameters.AddIfValidValue("limit", limit);

            return await PostAsync<ChartLocation<ChartNoteData<IEnumerable<long>>>>("/notes", parameters).Stay();
        }

        public async Task<ChartLocation<ChartBasicData<IEnumerable<long>>>> UsersAsync(string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("span", span) };
            parameters.AddIfValidValue("limit", limit);

            return await PostAsync<ChartLocation<ChartBasicData<IEnumerable<long>>>>("/users", parameters).Stay();
        }
    }
}