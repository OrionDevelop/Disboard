using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Mastodon.Enums;
using Disboard.Mastodon.Models;
using Disboard.Models;

namespace Disboard.Mastodon.Clients
{
    public class StatusesClient : ApiClient<MastodonClient>
    {
        protected internal StatusesClient(MastodonClient client) : base(client, "/api/v1/statuses") { }

        public async Task<Pagenator<Account>> RebloggedByAsync(long id, long? limit = null, long? sinceId = null, long? maxId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("since_id", sinceId);
            parameters.AddIfValidValue("max_id", maxId);

            return await GetAsync<Pagenator<Account>>($"/{id}/reblogged_by", parameters).Stay();
        }

        public async Task<Pagenator<Account>> FavouritedByAsync(long id, long? limit = null, long? sinceId = null, long? maxId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("since_id", sinceId);
            parameters.AddIfValidValue("max_id", maxId);

            return await GetAsync<Pagenator<Account>>($"/{id}/favourited_by", parameters).Stay();
        }

        public async Task<Status> ReblogAsync(long id)
        {
            return await PostAsync<Status>($"/{id}/reblog").Stay();
        }

        public async Task<Status> UnreblogAsync(long id)
        {
            return await PostAsync<Status>($"/{id}/unreblog").Stay();
        }

        public async Task<Status> FavouriteAsync(long id)
        {
            return await PostAsync<Status>($"/{id}/favourite").Stay();
        }

        public async Task<Status> UnfavouriteAsync(long id)
        {
            return await PostAsync<Status>($"/{id}/unfavourite").Stay();
        }

        public async Task<Status> MuteAsync(long id)
        {
            return await PostAsync<Status>($"/{id}/mute").Stay();
        }

        public async Task<Status> UnmuteAsync(long id)
        {
            return await PostAsync<Status>($"/{id}/unmute").Stay();
        }

        public async Task<Status> PinAsync(long id)
        {
            return await PostAsync<Status>($"/{id}/pin").Stay();
        }

        public async Task<Status> UnpinAsync(long id)
        {
            return await PostAsync<Status>($"/{id}/unpin").Stay();
        }

        public async Task<Context> ContextAsync(long id)
        {
            return await GetAsync<Context>($"/{id}/context").Stay();
        }

        public async Task<Card> CardAsync(long id)
        {
            return await GetAsync<Card>($"/{id}/card").Stay();
        }

        #region UpdateAsync

        public async Task<Status> UpdateAsync(string status, long? inReplyToId = null, List<long> mediaIds = null, bool? isSensitive = null, string spoilerText = null,
                                              VisibilityType? visibility = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("status", status)
            };
            parameters.AddIfValidValue("in_reply_to_id", inReplyToId);
            mediaIds?.ForEach(w => parameters.Add(new KeyValuePair<string, object>("media_ids[]", w)));
            parameters.AddIfValidValue("sensitive", isSensitive);
            parameters.AddIfValidValue("spoiler_text", spoilerText);
            parameters.AddIfValidValue("visibility", visibility.ToString().ToLower());

            return await PostAsync<Status>(parameters: parameters).Stay();
        }

        public async Task<ScheduledStatus> UpdateAsync(string status, long? inReplyToId = null, List<long> mediaIds = null, bool? isSensitive = null, string spoilerText = null,
                                              VisibilityType? visibility = null, DateTime? scheduledAt = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("status", status)
            };
            parameters.AddIfValidValue("in_reply_to_id", inReplyToId);
            mediaIds?.ForEach(w => parameters.Add(new KeyValuePair<string, object>("media_ids[]", w)));
            parameters.AddIfValidValue("sensitive", isSensitive);
            parameters.AddIfValidValue("spoiler_text", spoilerText);
            parameters.AddIfValidValue("visibility", visibility.ToString().ToLower());
            parameters.AddIfValidValue("scheduled_at", scheduledAt);

            return await PostAsync<ScheduledStatus>(parameters: parameters).Stay();
        }

        #endregion

        public async Task<Status> ShowAsync(long id)
        {
            return await GetAsync<Status>($"/{id}").Stay();
        }

        public async Task DestroyAsync(long id)
        {
            await DeleteAsync($"/{id}").Stay();
        }
    }
}