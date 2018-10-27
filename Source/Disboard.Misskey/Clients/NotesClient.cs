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

            return await PostAsync<List<Note>>("/conversation", parameters);
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

            var response = await PostAsync<ApiResponse>("/create", parameters);
            return response.Extends["createdNote"].ToObject<Note>();
        }

        public async Task DeleteAsync(string noteId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("noteId", noteId)};

            await PostAsync("/delete", parameters);
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

            return await PostAsync<List<Note>>("/global-timeline", parameters);
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

            return await PostAsync<List<Note>>("/hybrid-timeline", parameters);
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

            return await PostAsync<List<Note>>("/local-timeline", parameters);
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
    }
}