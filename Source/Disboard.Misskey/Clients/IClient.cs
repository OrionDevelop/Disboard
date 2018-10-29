using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients
{
    // ReSharper disable once InconsistentNaming
    public class IClient : ApiClient<MisskeyClient>
    {
        protected internal IClient(MisskeyClient client) : base(client, "/api/i") { }

        public async Task<List<Note>> FavoritesAsync(int? limit = null, string sinceId = null, string untilId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("sinceId", sinceId);
            parameters.AddIfValidValue("untilId", untilId);

            return await PostAsync<List<Note>>("/favorites", parameters).Stay();
        }

        public async Task<List<Notification>> NotificationsAsync(bool? following = null, bool? markAsRead = null, int? limit = null, string sinceId = null, string untilId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("following", following);
            parameters.AddIfValidValue("markAsRead", markAsRead);
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("sinceId", sinceId);
            parameters.AddIfValidValue("untilId", untilId);

            return await PostAsync<List<Notification>>("/notifications", parameters).Stay();
        }

        public async Task<User> PinAsync(string noteId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("noteId", noteId)};

            return await PostAsync<User>("/pin", parameters).Stay();
        }

        public async Task<User> UnpinAsync(string noteId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("noteId", noteId)};

            return await PostAsync<User>("/unpin", parameters).Stay();
        }

        public async Task ReadAllUnreadNotesAsync()
        {
            await PostAsync("/read_all_unread_notes").Stay();
        }

        public async Task<User> UpdateAsync(string name = null, string description = null, string location = null, string birthday = null, string avatarId = null, string bannerId = null,
                                            string wallpaperId = null, bool? carefulBot = null, bool? isBot = null, bool? isCat = null, bool? autoWatch = null, bool? alwaysMarkNsfw = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("name", name);
            parameters.AddIfValidValue("description", description);
            parameters.AddIfValidValue("location", location);
            parameters.AddIfValidValue("birthday", birthday);
            parameters.AddIfValidValue("avatarId", avatarId);
            parameters.AddIfValidValue("bannerOd", bannerId);
            parameters.AddIfValidValue("wallpaperId", wallpaperId);
            parameters.AddIfValidValue("carefulBot", carefulBot);
            parameters.AddIfValidValue("isBot", isBot);
            parameters.AddIfValidValue("isCat", isCat);
            parameters.AddIfValidValue("autoWatch", autoWatch);
            parameters.AddIfValidValue("alwaysMarkAsNsfw", alwaysMarkNsfw);

            return await PostAsync<User>("/update", parameters).Stay();
        }
    }
}