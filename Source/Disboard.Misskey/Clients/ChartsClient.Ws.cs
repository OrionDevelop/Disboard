using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Models;
using Disboard.Models;

namespace Disboard.Misskey.Clients
{
    public partial class ChartsClient
    {
        public async Task<ChartLocation<ChartCountData>> ActiveUsersWsAsync(string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("span", span) };
            parameters.AddIfValidValue("limit", limit);

            return await SendWsAsync<ChartLocation<ChartCountData>>("/active-users", parameters);
        }

        public async Task<ChartLocation<ChartDriveData1<IEnumerable<long>>>> DriveWsAsync(string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("span", span) };
            parameters.AddIfValidValue("limit", limit);

            return await SendWsAsync<ChartLocation<ChartDriveData1<IEnumerable<long>>>>("/drive", parameters).Stay();
        }

        public async Task<ChartBasicData<IEnumerable<long>>> FederationWsAsync(string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("span", span) };
            parameters.AddIfValidValue("limit", limit);

            var response = await SendWsAsync<ApiResponse>("/federation", parameters).Stay();
            return response.Extends["instance"].ToObject<ChartBasicData<IEnumerable<long>>>();
        }

        public async Task<ChartLocation<ChartCountData>> HashtagWsAsync(string tag, string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("tag", tag),
                new KeyValuePair<string, object>("span", span)
            };
            parameters.AddIfValidValue("limit", limit);

            return await SendWsAsync<ChartLocation<ChartCountData>>("/hashtag", parameters).Stay();
        }

        public async Task<ChartInstanceData> InstanceWsAsync(string host, string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("host", host),
                new KeyValuePair<string, object>("span", span)
            };
            parameters.AddIfValidValue("limit", limit);

            return await SendWsAsync<ChartInstanceData>("/instance", parameters).Stay();
        }

        public async Task<ChartNetworkData<IEnumerable<long>>> NetworkWsAsync(string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("span", span) };
            parameters.AddIfValidValue("limit", limit);

            return await SendWsAsync<ChartNetworkData<IEnumerable<long>>>("/network", parameters).Stay();
        }

        public async Task<ChartLocation<ChartNoteData<IEnumerable<long>>>> NoteWsAsync(string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("span", span) };
            parameters.AddIfValidValue("limit", limit);

            return await SendWsAsync<ChartLocation<ChartNoteData<IEnumerable<long>>>>("/notes", parameters).Stay();
        }

        public async Task<ChartLocation<ChartBasicData<IEnumerable<long>>>> UsersWsAsync(string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("span", span) };
            parameters.AddIfValidValue("limit", limit);

            return await SendWsAsync<ChartLocation<ChartBasicData<IEnumerable<long>>>>("/users", parameters).Stay();
        }
    }
}