using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey
{
    public partial class MisskeyClient
    {
        public async Task<Chart> ChartWsAsync(int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);

            return await SendWsAsync<Chart>("chart").Stay();
        }

        public async Task<Drive> DriveWsAsync()
        {
            return await SendWsAsync<Drive>("drive").Stay();
        }

        // ReSharper disable once InconsistentNaming
        public async Task<User> IWsAsync()
        {
            return await SendWsAsync<User>("i").Stay();
        }

        public async Task<Metadata> MetaWsAsync(bool? detail = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("detail", detail);

            return await SendWsAsync<Metadata>("meta", parameters).Stay();
        }

        public async Task<List<Note>> NotesWsAsync(bool? local = null, bool? reply = null, bool? renote = null, bool? withFiles = null, bool? poll = null, int? limit = null, string sinceId = null, string untilId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("local", local);
            parameters.AddIfValidValue("reply", reply);
            parameters.AddIfValidValue("renote", renote);
            parameters.AddIfValidValue("withFiles", withFiles);
            parameters.AddIfValidValue("poll", poll);
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("sinceId", sinceId);
            parameters.AddIfValidValue("untilId", untilId);

            return await SendWsAsync<List<Note>>("notes", parameters).Stay();
        }

        public async Task<Stats> StatsWsAsync()
        {
            return await SendWsAsync<Stats>("stats").Stay();
        }

        public async Task<List<User>> UsersWsAsync(int? limit = null, int? offset = null, string sort = null, string state = null, string origin = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("offset", offset);
            parameters.AddIfValidValue("sort", sort);
            parameters.AddIfValidValue("state", state);
            parameters.AddIfValidValue("origin", origin);

            return await SendWsAsync<List<User>>("users", parameters).Stay();
        }
    }
}