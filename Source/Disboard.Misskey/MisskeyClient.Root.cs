using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Models;
using Disboard.Misskey.Models.Streaming;

namespace Disboard.Misskey
{
    public partial class MisskeyClient
    {
        public async Task<Chart> ChartAsync(int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);

            return await PostAsync<Chart>("/api/chart").Stay();
        }

        public async Task<Drive> DriveAsync()
        {
            return await PostAsync<Drive>("/api/drive").Stay();
        }

        // ReSharper disable once InconsistentNaming
        public async Task<User> IAsync()
        {
            return await PostAsync<User>("/api/i").Stay();
        }

        // ReSharper disable once InconsistentNaming
        public async Task<User> IWsAsync()
        {
            return await Streaming.SendAsync<User>(WsRestRequestObject.CreateRestRequest("i"));
        }

        public async Task<Instance> MetaAsync()
        {
            return await PostAsync<Instance>("/api/meta").Stay();
        }

        public async Task<List<Note>> NotesAsync(bool? local = null, bool? reply = null, bool? renote = null, bool? withFiles = null,
                                                 bool? poll = null, int? limit = null, string sinceId = null, string untilId = null)
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

            return await PostAsync<List<Note>>("/api/notes", parameters).Stay();
        }

        public async Task<Stats> StatsAsync()
        {
            return await PostAsync<Stats>("/api/stats").Stay();
        }

        public async Task<List<User>> UsersAsync(int? limit = null, int? offset = null, string sort = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("offset", offset);
            parameters.AddIfValidValue("sort", sort);

            return await PostAsync<List<User>>("/api/users", parameters).Stay();
        }
    }
}