using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class Stats : ApiResponse
    {
        [JsonProperty("notesCount")]
        public long NotesCount { get; set; }

        [JsonProperty("usersCount")]
        public long UsersCount { get; set; }

        [JsonProperty("originalNotesCount")]
        public long OriginalNotesCount { get; set; }

        [JsonProperty("originalUsersCount")]
        public long OriginalUsersCount { get; set; }
    }
}