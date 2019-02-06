using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Mastodon.Models;
using Disboard.Models;

namespace Disboard.Mastodon.Clients
{
    public class AccountsClient : ApiClient<MastodonClient>
    {
        protected internal AccountsClient(MastodonClient client) : base(client, "/api/v1/accounts") { }

        public async Task<CredentialAccount> UpdateCredentialsAsync(string displayName = null, string note = null, string avatar = null, string header = null, bool? isLocked = null, bool? isBot = null,
                                                                    List<Field> fields = null, Source source = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("display_name", displayName);
            parameters.AddIfValidValue("note", note);
            parameters.AddIfValidValue("avatar", avatar); // marked as stream
            parameters.AddIfValidValue("header", header); // marked as stream
            parameters.AddIfValidValue("locked", isLocked);
            parameters.AddIfValidValue("bot", isBot);
            if (fields != null)
                foreach (var tuple in fields.Select((w, i) => new { Index = i, Field = w }))
                {
                    parameters.AddIfValidValue($"fields_attributes[{tuple.Index}][name]", tuple.Field.Name);
                    parameters.AddIfValidValue($"fields_attributes[{tuple.Index}][value]", tuple.Field.Value);
                }
            parameters.AddIfValidValue("source[sensitive]", source?.IsSensitive);
            parameters.AddIfValidValue("source[language]", source?.Language);
            parameters.AddIfValidValue("source[privacy]", source?.Privacy);

            return await PatchAsync<CredentialAccount>("/update_credentials", parameters).Stay();
        }

        public async Task<List<Account>> SearchAsync(string q, long? limit = null, bool? isFollowing = null, bool? isResolve = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("q", q)
            };
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("following", isFollowing);
            parameters.AddIfValidValue("resolve", isResolve);

            return await GetAsync<List<Account>>("/search", parameters).Stay();
        }

        public async Task<List<Relationship>> RelationshipsAsync(List<long> id)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            if (id.Count == 1)
                parameters.Add(new KeyValuePair<string, object>("id", id[0]));
            else
                id.ForEach(w => parameters.Add(new KeyValuePair<string, object>("id[]", w)));

            return await GetAsync<List<Relationship>>("/relationships", parameters).Stay();
        }

        public async Task<Pagenator<Status>> StatusesAsync(long id, long? limit = null, long? sinceId = null, long? minId = null, long? maxId = null, bool? isPinned = null, bool? isOnlyMedia = null,
                                                           bool? excludeReplies = null, bool? excludeReblogs = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("since_id", sinceId);
            parameters.AddIfValidValue("min_id", minId);
            parameters.AddIfValidValue("max_id", maxId);
            parameters.AddIfValidValue("pinned", isPinned);
            parameters.AddIfValidValue("only_media", isOnlyMedia);
            parameters.AddIfValidValue("exclude_replies", excludeReplies);
            parameters.AddIfValidValue("exclude_reblogs", excludeReblogs);

            return await GetAsync<Pagenator<Status>>($"/{id}/statuses", parameters).Stay();
        }

        public async Task<Pagenator<Account>> FollowersAsync(long id, long? limit = null, long? sinceId = null, long? maxId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("since_id", sinceId);
            parameters.AddIfValidValue("max_id", maxId);

            return await GetAsync<Pagenator<Account>>($"/{id}/followers", parameters).Stay();
        }

        public async Task<Pagenator<Account>> FollowingAsync(long id, long? limit = null, long? sinceId = null, long? maxId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("since_id", sinceId);
            parameters.AddIfValidValue("max_id", maxId);

            return await GetAsync<Pagenator<Account>>($"/{id}/following", parameters).Stay();
        }

        public async Task<List<List>> ListsAsync(long id)
        {
            return await GetAsync<List<List>>($"/{id}/lists").Stay();
        }

        public async Task<Account> ShowAsync(long id)
        {
            return await GetAsync<Account>($"/{id}").Stay();
        }

        public async Task<Relationship> FollowAsync(long id, bool? reblogs = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("reblogs", reblogs);

            return await PostAsync<Relationship>($"/{id}/follow", parameters).Stay();
        }

        public async Task<Relationship> UnfollowAsync(long id)
        {
            return await PostAsync<Relationship>($"/{id}/unfollow").Stay();
        }

        public async Task<Relationship> BlockAsync(long id)
        {
            return await PostAsync<Relationship>($"/{id}/block").Stay();
        }

        public async Task<Relationship> UnblockAsync(long id)
        {
            return await PostAsync<Relationship>($"/{id}/unblock").Stay();
        }

        public async Task<Relationship> MuteAsync(long id, bool? notifications = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("notifications", notifications);

            return await PostAsync<Relationship>($"/{id}/mute", parameters).Stay();
        }

        public async Task<Relationship> UnmuteAsync(long id)
        {
            return await PostAsync<Relationship>($"/{id}/unmute").Stay();
        }

        public async Task<Relationship> PinAsync(long id)
        {
            return await PostAsync<Relationship>($"/{id}/pin").Stay();
        }

        public async Task<Relationship> UnpinAsync(long id)
        {
            return await PostAsync<Relationship>($"/{id}/unpin").Stay();
        }

        public async Task<CredentialAccount> VerifyCredentialsAsync()
        {
            return await GetAsync<CredentialAccount>("/verify_credentials").Stay();
        }

        public async Task<Tokens> CreateAsync(string username, string email, string password, bool agreement, string locale)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("username", username),
                new KeyValuePair<string, object>("email", email),
                new KeyValuePair<string, object>("password", password),
                new KeyValuePair<string, object>("agreement", agreement),
                new KeyValuePair<string, object>("locale", locale)
            };

            return await PostAsync<Tokens>(parameters: parameters).Stay();
        }
    }
}