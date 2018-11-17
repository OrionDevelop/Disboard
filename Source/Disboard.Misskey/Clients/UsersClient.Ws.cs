using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients
{
    public partial class UsersClient
    {
        public async Task<UserWithCursor> FollowersWsAsync(string userId, bool? iknow = null, int? limit = null, string cursor = null)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};
            parameters.AddIfValidValue("iknow", iknow);
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("cursor", cursor);

            return await SendWsAsync<UserWithCursor>("/followers", parameters).Stay();
        }

        public async Task<UserWithCursor> FollowingWsAsync(string userId, bool? iknow = null, int? limit = null, string cursor = null)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};
            parameters.AddIfValidValue("iknow", iknow);
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("cursor", cursor);

            return await SendWsAsync<UserWithCursor>("/following", parameters).Stay();
        }

        public async Task<List<FrequentlyRepliedUser>> GetFrequentlyRepliedUsersWsAsync(string userId, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("userId", userId)};
            parameters.AddIfValidValue("limit", limit);

            return await SendWsAsync<List<FrequentlyRepliedUser>>("/get_frequently_replied_users", parameters).Stay();
        }

        public async Task<List<Note>> NotesWsAsync(string userId = null, string username = null, string host = null, bool? includeReplies = null, int? limit = null,
                                                   string sinceId = null, string untilId = null, long? sinceDate = null, long? untilDate = null,
                                                   bool? includeMyRenotes = null, bool? includeRenotedMyNotes = null, bool? includeLocalRenotes = null,
                                                   bool? withFiles = null, string fileType = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("userId", userId);
            parameters.AddIfValidValue("username", username);
            parameters.AddIfValidValue("host", host);
            parameters.AddIfValidValue("includeReplies", includeReplies);
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("sinceId", sinceId);
            parameters.AddIfValidValue("untilId", untilId);
            parameters.AddIfValidValue("sinceDate", sinceDate);
            parameters.AddIfValidValue("untilDate", untilDate);
            parameters.AddIfValidValue("includeMyRenotes", includeMyRenotes);
            parameters.AddIfValidValue("includeRenotedMyNotes", includeRenotedMyNotes);
            parameters.AddIfValidValue("includeLocalRenotes", includeLocalRenotes);
            parameters.AddIfValidValue("withFiles", withFiles);
            parameters.AddIfValidValue("fileType", fileType);

            return await SendWsAsync<List<Note>>("/notes", parameters).Stay();
        }

        public async Task<List<User>> RecommendationWsAsync(int? limit = null, int? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("offset", offset);

            return await SendWsAsync<List<User>>("/recommendation", parameters).Stay();
        }

        public async Task<List<Relation>> RelationWsAsync(List<string> userIds)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("userId", userIds)
            };

            return await SendWsAsync<List<Relation>>("/relation", parameters).Stay();
        }

        public async Task<List<User>> SearchWsAsync(string query, int? limit = null, int? offset = null, bool? localOnly = null)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("query", query)};
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("offset", offset);
            parameters.AddIfValidValue("localOnly", localOnly);

            return await SendWsAsync<List<User>>("/search", parameters).Stay();
        }

        public async Task<List<User>> ShowWsAsync(string userId = null, List<string> userIds = null, string username = null, string host = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("userId", userId);
            parameters.AddIfValidValue("userIds", userIds);
            parameters.AddIfValidValue("username", username);
            parameters.AddIfValidValue("host", host);

            if (userIds != null)
                return await SendWsAsync<List<User>>("/show", parameters).Stay();
            return new List<User> {await SendWsAsync<User>("/show", parameters).Stay()};
        }
    }
}