using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients.Charts
{
    public class UsersClient : ApiClient<MisskeyClient>
    {
        protected internal UsersClient(MisskeyClient client) : base(client, "/api/charts/user") { }

        public async Task<ChartDriveData<IEnumerable<long>>> DriveAsync(string userId, string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("userId", userId),
                new KeyValuePair<string, object>("span", span)
            };
            parameters.AddIfValidValue("limit", limit);

            return await PostAsync<ChartDriveData<IEnumerable<long>>>("/drive", parameters);
        }

        public async Task<ChartLocation<ChartFollowingData>> FollowingAsync(string userId, string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("userId", userId),
                new KeyValuePair<string, object>("span", span)
            };
            parameters.AddIfValidValue("limit", limit);

            return await PostAsync<ChartLocation<ChartFollowingData>>("/following", parameters);
        }

        public async Task<ChartNoteData<IEnumerable<long>>> NotesAsync(string userId, string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("userId", userId),
                new KeyValuePair<string, object>("span", span)
            };
            parameters.AddIfValidValue("limit", limit);

            return await PostAsync<ChartNoteData<IEnumerable<long>>>("/notes", parameters);
        }

        public async Task<ChartLocation<ChartCountData>> ReactionsAsync(string userId, string span, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("userId", userId),
                new KeyValuePair<string, object>("span", span)
            };
            parameters.AddIfValidValue("limit", limit);

            return await PostAsync<ChartLocation<ChartCountData>>("/reactions", parameters);
        }
    }
}