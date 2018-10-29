using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Misskey.Clients.Notes;
using Disboard.Misskey.Models;
using Disboard.Models;

namespace Disboard.Misskey.Clients
{
    public class NotesClient : ApiClient<MisskeyClient>
    {
        public FavoritesClient FavoritesClient { get; }
        public PollsClient Polls { get; }
        public ReactionsClient Reactions { get; }

        protected internal NotesClient(MisskeyClient client) : base(client, "/api/notes")
        {
            FavoritesClient = new FavoritesClient(client);
            Polls = new PollsClient(client);
            Reactions = new ReactionsClient(client);
        }

        public async Task<List<Note>> ConversationAsync(string noteId, int? limit = null, int? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("noteId", noteId)};
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("offset", offset);

            return await PostAsync<List<Note>>("/conversation", parameters).Stay();
        }

        public async Task<Note> CreateAsync(string text = null, string visibility = null, List<string> visibleUserIds = null, string cw = null, bool? viaMobile = null, Geo geo = null,
                                            List<string> fileIds = null, string renoteId = null, Poll poll = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("text", text);
            parameters.AddIfValidValue("visibility", visibility);
            parameters.AddIfValidValue("visibleUserIds", visibleUserIds);
            parameters.AddIfValidValue("cw", cw);
            parameters.AddIfValidValue("viaMobile", viaMobile);
            parameters.AddIfValidValue("geo", geo);
            parameters.AddIfValidValue("fileIds", fileIds);
            parameters.AddIfValidValue("renoteId", renoteId);
            parameters.AddIfValidValue("poll", poll);

            var response = await PostAsync<ApiResponse>("/create", parameters).Stay();
            return response.Extends["createdNote"].ToObject<Note>();
        }

        public async Task DeleteAsync(string noteId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("noteId", noteId)};

            await PostAsync("/delete", parameters).Stay();
        }

        public async Task<List<Note>> GlobalTimelineAsync(int? limit = null, bool? withFiles = null, string sinceId = null, string untilId = null,
                                                          long? sinceDate = null, long? untilDate = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("withFiles", withFiles);
            parameters.AddIfValidValue("sinceId", sinceId);
            parameters.AddIfValidValue("untilId", untilId);
            parameters.AddIfValidValue("sinceData", sinceDate);
            parameters.AddIfValidValue("untilDate", untilDate);

            return await PostAsync<List<Note>>("/global-timeline", parameters).Stay();
        }

        public async Task<List<Note>> HybridTimelineAsync(int? limit = null, bool? includeMyRenotes = null, bool? includeRenotedMyNotes = null,
                                                          bool? includeLocalRenotes = null, bool? withFiles = null,
                                                          string sinceId = null, string untilId = null, long? sinceDate = null, long? untilDate = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("includeMyRenotes", includeMyRenotes);
            parameters.AddIfValidValue("includeRenotedMyNotes", includeRenotedMyNotes);
            parameters.AddIfValidValue("includeLocalRenotes", includeLocalRenotes);
            parameters.AddIfValidValue("withFiles", withFiles);
            parameters.AddIfValidValue("sinceId", sinceId);
            parameters.AddIfValidValue("untilId", untilId);
            parameters.AddIfValidValue("sinceData", sinceDate);
            parameters.AddIfValidValue("untilDate", untilDate);

            return await PostAsync<List<Note>>("/hybrid-timeline", parameters).Stay();
        }

        public async Task<List<Note>> LocalTimelineAsync(int? limit = null, bool? withFiles = null, string fileType = null, bool? excludeNswf = null,
                                                         string sinceId = null, string untilId = null, long? sinceDate = null, long? untilDate = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("withFiles", withFiles);
            parameters.AddIfValidValue("fileType", fileType);
            parameters.AddIfValidValue("excludeNswf", excludeNswf);
            parameters.AddIfValidValue("sinceId", sinceId);
            parameters.AddIfValidValue("untilId", untilId);
            parameters.AddIfValidValue("sinceData", sinceDate);
            parameters.AddIfValidValue("untilDate", untilDate);

            return await PostAsync<List<Note>>("/local-timeline", parameters).Stay();
        }

        public async Task<List<Note>> MentionsAsync(int? limit = null, bool? following = null, string visibility = null, string sinceId = null, string untilId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("following", following);
            parameters.AddIfValidValue("visibility", visibility);
            parameters.AddIfValidValue("sinceId", sinceId);
            parameters.AddIfValidValue("untilId", untilId);

            return await PostAsync<List<Note>>("/mentions", parameters);
        }

        public async Task<List<NoteReaction>> ReactionsAsync(string noteId, int? limit = null, int? offset = null, string sort = null)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("noteId", noteId)};
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("offset", offset);
            parameters.AddIfValidValue("sort", sort);

            return await PostAsync<List<NoteReaction>>("/reactions", parameters);
        }

        public async Task<List<Note>> RepliesAsync(string noteId, int? limit = null, int? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("noteId", noteId)};
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("offset", offset);

            return await PostAsync<List<Note>>("/replies", parameters);
        }

        public async Task<List<Note>> RepostsAsync(string noteId, int? limit = null, string sinceId = null, string untilId = null)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("noteId", noteId)};
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("sinceId", sinceId);
            parameters.AddIfValidValue("untilId", untilId);

            return await PostAsync<List<Note>>("/reposts", parameters);
        }

        public async Task<List<Note>> SearchByTagAsync(string tag = null, IEnumerable<string> query = null, IEnumerable<string> includeUserIds = null, IEnumerable<string> excludeUserIds = null,
                                                       IEnumerable<string> includeUserUsernames = null, IEnumerable<string> excludeUserUsernames = null,
                                                       bool? following = null, string mute = null, bool? reply = null, bool? renote = null, bool? withFiles = null,
                                                       bool? poll = null, string untilId = null, long? sinceDate = null, long? untilDate = null, int? offset = null, int? limit = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("tag", tag);
            parameters.AddIfValidValue("query", query);
            parameters.AddIfValidValue("includeUserIds", includeUserIds);
            parameters.AddIfValidValue("excludeUserIds", excludeUserIds);
            parameters.AddIfValidValue("includeUserUsernames", includeUserUsernames);
            parameters.AddIfValidValue("excludeUserUsernames", excludeUserUsernames);
            parameters.AddIfValidValue("following", following);
            parameters.AddIfValidValue("mute", mute);
            parameters.AddIfValidValue("reply", reply);
            parameters.AddIfValidValue("renote", renote);
            parameters.AddIfValidValue("withFiles", withFiles);
            parameters.AddIfValidValue("poll", poll);
            parameters.AddIfValidValue("untilId", untilId);
            parameters.AddIfValidValue("sinceDate", sinceDate);
            parameters.AddIfValidValue("untilDate", untilDate);
            parameters.AddIfValidValue("offset", offset);
            parameters.AddIfValidValue("limit", limit);

            return await PostAsync<List<Note>>("/search_by_tag", parameters);
        }

        public async Task<List<Note>> SearchAsync(string query, int? limit = null, int? offset = null)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("query", query)};
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("offset", offset);

            return await PostAsync<List<Note>>("/search", parameters);
        }

        public async Task<Note> ShowAsync(string noteId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("noteId", noteId)};

            return await PostAsync<Note>("/show", parameters);
        }

        public async Task<List<Note>> TimelineAsync(int? limit = null, string sinceId = null, string untilId = null, long? sinceDate = null, long? untilDate = null,
                                                    bool? includeMyRenotes = null, bool? includeRenotedMyNotes = null, bool? includeLocalRenotes = null, bool? withFiles = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("sinceId", sinceId);
            parameters.AddIfValidValue("untilId", untilId);
            parameters.AddIfValidValue("sinceDate", sinceDate);
            parameters.AddIfValidValue("untilDate", untilDate);
            parameters.AddIfValidValue("includeMyRenotes", includeMyRenotes);
            parameters.AddIfValidValue("includeRenotedMyNotes", includeRenotedMyNotes);
            parameters.AddIfValidValue("includeLocalRenotes", includeLocalRenotes);
            parameters.AddIfValidValue("withFiles", withFiles);

            return await PostAsync<List<Note>>("/timeline", parameters);
        }

        public async Task<List<Note>> TrendAsync(int? limit = null, int? offset = null, bool? reply = null, bool? renote = null, bool? media = null, bool? poll = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("offset", offset);
            parameters.AddIfValidValue("reply", reply);
            parameters.AddIfValidValue("renote", renote);
            parameters.AddIfValidValue("media", media);
            parameters.AddIfValidValue("poll", poll);

            return await PostAsync<List<Note>>("/trend", parameters);
        }

        public async Task<List<Note>> UserListTimelineAsync(string listId, int? limit = null, string sinceId = null, string untilId = null, long? sinceDate = null, long? untilDate = null,
                                                            bool? includeMyRenotes = null, bool? includeRenotedMyNotes = null, bool? includeLocalRenotes = null, bool? withFiles = null)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("listId", listId)};
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("sinceId", sinceId);
            parameters.AddIfValidValue("untilId", untilId);
            parameters.AddIfValidValue("sinceDate", sinceDate);
            parameters.AddIfValidValue("untilDate", untilDate);
            parameters.AddIfValidValue("includeMyRenotes", includeMyRenotes);
            parameters.AddIfValidValue("includeRenotedMyNotes", includeRenotedMyNotes);
            parameters.AddIfValidValue("includeLocalRenotes", includeLocalRenotes);
            parameters.AddIfValidValue("withFiles", withFiles);

            return await PostAsync<List<Note>>("/user-list-timeline", parameters);
        }
    }
}