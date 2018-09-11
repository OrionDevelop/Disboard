﻿using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Mastodon.Models;

namespace Disboard.Mastodon.Clients
{
    public class TimelinesClient : ApiClient<MastodonClient>
    {
        internal TimelinesClient(MastodonClient client) : base(client, "/api/v1/timelines") { }

        public async Task<List<Status>> DirectAsync(bool? isLocal = null, long? limit = null, long? sinceId = null, long? maxId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("local", isLocal);
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("since_id", sinceId);
            parameters.AddIfValidValue("max_id", maxId);

            return await GetAsync<List<Status>>("/direct", parameters).Stay();
        }

        public async Task<List<Status>> HomeAsync(bool? isLocal = null, long? limit = null, long? sinceId = null, long? maxId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("local", isLocal);
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("since_id", sinceId);
            parameters.AddIfValidValue("max_id", maxId);

            return await GetAsync<List<Status>>("/home", parameters).Stay();
        }

        public async Task<List<Status>> PublicAsync(bool? isLocal = null, bool? isOnlyMedia = null, long? limit = null, long? sinceId = null, long? maxId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("local", isLocal);
            parameters.AddIfValidValue("only_media", isOnlyMedia);
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("since_id", sinceId);
            parameters.AddIfValidValue("max_id", maxId);

            return await GetAsync<List<Status>>("/public", parameters).Stay();
        }

        public async Task<List<Status>> TagAsync(string slug, bool? isLocal = null, bool? isOnlyMedia = null, long? limit = null, long? sinceId = null, long? maxId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("local", isLocal);
            parameters.AddIfValidValue("only_media", isOnlyMedia);
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("since_id", sinceId);
            parameters.AddIfValidValue("max_id", maxId);

            return await GetAsync<List<Status>>($"/tag/{slug}", parameters).Stay();
        }

        public async Task<List<Status>> ListAsync(long id, long? limit = null, long? sinceId = null, long? maxId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("since_id", sinceId);
            parameters.AddIfValidValue("max_id", maxId);

            return await GetAsync<List<Status>>($"/list/{id}", parameters).Stay();
        }
    }
}