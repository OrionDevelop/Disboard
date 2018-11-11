using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Mastodon.Models;
using Disboard.Models;

namespace Disboard.Mastodon.Clients
{
    public class TimelinesClient : ApiClient<MastodonClient>
    {
        protected internal TimelinesClient(MastodonClient client) : base(client, "/api/v1/timelines") { }

        [Obsolete("Please use conversations API")]
        public async Task<Pagenator<Status>> DirectAsync(bool? isLocal = null, long? limit = null, long? sinceId = null, long? maxId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("local", isLocal);
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("since_id", sinceId);
            parameters.AddIfValidValue("max_id", maxId);

            return await GetAsync<Pagenator<Status>>("/direct", parameters).Stay();
        }

        public async Task<Pagenator<Status>> HomeAsync(bool? isLocal = null, long? limit = null, long? sinceId = null, long? minId = null, long? maxId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("local", isLocal);
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("since_id", sinceId);
            parameters.AddIfValidValue("min_id", minId);
            parameters.AddIfValidValue("max_id", maxId);

            return await GetAsync<Pagenator<Status>>("/home", parameters).Stay();
        }

        public async Task<Pagenator<Status>> PublicAsync(bool? isLocal = null, bool? isOnlyMedia = null, long? limit = null, long? sinceId = null, long? minId = null, long? maxId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("local", isLocal);
            parameters.AddIfValidValue("only_media", isOnlyMedia);
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("since_id", sinceId);
            parameters.AddIfValidValue("min_id", minId);
            parameters.AddIfValidValue("max_id", maxId);

            return await GetAsync<Pagenator<Status>>("/public", parameters).Stay();
        }

        public async Task<Pagenator<Status>> TagAsync(string slug, bool? isLocal = null, bool? isOnlyMedia = null, long? limit = null, long? sinceId = null, long? minId = null, long? maxId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("local", isLocal);
            parameters.AddIfValidValue("only_media", isOnlyMedia);
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("since_id", sinceId);
            parameters.AddIfValidValue("min_id", minId);
            parameters.AddIfValidValue("max_id", maxId);

            return await GetAsync<Pagenator<Status>>($"/tag/{slug}", parameters).Stay();
        }

        public async Task<Pagenator<Status>> ListAsync(long id, long? limit = null, long? sinceId = null, long? minId = null, long? maxId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("since_id", sinceId);
            parameters.AddIfValidValue("min_id", minId);
            parameters.AddIfValidValue("max_id", maxId);

            return await GetAsync<Pagenator<Status>>($"/list/{id}", parameters).Stay();
        }
    }
}