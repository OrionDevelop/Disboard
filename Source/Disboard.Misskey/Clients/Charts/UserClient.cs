using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients.Charts
{
    public partial class UserClient : MisskeyApiClient
    {
        protected internal UserClient(MisskeyClient client) : base(client, "charts/user") { }

        public async Task<ChartDriveData1<IEnumerable<long>>> DriveAsync(string userId, string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("userId", userId),
                new KeyValuePair<string, object>("span", span)
            };
            parameters.AddIfValidValue("limit", limit);

            return await PostAsync<ChartDriveData1<IEnumerable<long>>>("/drive", parameters).Stay();
        }

        public async Task<ChartLocation<ChartFollowingData>> FollowingAsync(string userId, string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("userId", userId),
                new KeyValuePair<string, object>("span", span)
            };
            parameters.AddIfValidValue("limit", limit);

            return await PostAsync<ChartLocation<ChartFollowingData>>("/following", parameters).Stay();
        }

        public async Task<ChartNoteData<IEnumerable<long>>> NotesAsync(string userId, string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("userId", userId),
                new KeyValuePair<string, object>("span", span)
            };
            parameters.AddIfValidValue("limit", limit);

            return await PostAsync<ChartNoteData<IEnumerable<long>>>("/notes", parameters).Stay();
        }

        public async Task<ChartLocation<ChartCountData>> ReactionsAsync(string userId, string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("userId", userId),
                new KeyValuePair<string, object>("span", span)
            };
            parameters.AddIfValidValue("limit", limit);

            return await PostAsync<ChartLocation<ChartCountData>>("/reactions", parameters).Stay();
        }
    }
}