using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients.Charts
{
    public partial class UserClient
    {
        public async Task<ChartDriveData1<IEnumerable<long>>> DriveWsAsync(string userId, string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("userId", userId),
                new KeyValuePair<string, object>("span", span)
            };
            parameters.AddIfValidValue("limit", limit);

            return await SendWsAsync<ChartDriveData1<IEnumerable<long>>>("/drive", parameters).Stay();
        }

        public async Task<ChartLocation<ChartFollowingData>> FollowingWsAsync(string userId, string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("userId", userId),
                new KeyValuePair<string, object>("span", span)
            };
            parameters.AddIfValidValue("limit", limit);

            return await SendWsAsync<ChartLocation<ChartFollowingData>>("/following", parameters).Stay();
        }

        public async Task<ChartNoteData<IEnumerable<long>>> NotesWsAsync(string userId, string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("userId", userId),
                new KeyValuePair<string, object>("span", span)
            };
            parameters.AddIfValidValue("limit", limit);

            return await SendWsAsync<ChartNoteData<IEnumerable<long>>>("/notes", parameters).Stay();
        }

        public async Task<ChartLocation<ChartCountData>> ReactionsWsAsync(string userId, string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("userId", userId),
                new KeyValuePair<string, object>("span", span)
            };
            parameters.AddIfValidValue("limit", limit);

            return await SendWsAsync<ChartLocation<ChartCountData>>("/reactions", parameters).Stay();
        }
    }
}