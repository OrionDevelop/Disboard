using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class Message : ApiResponse
    {
        [JsonProperty("fileId")]
        public string FileId { get; set; }

        [JsonProperty("file")]
        public File File { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("isRead")]
        public bool IsRead { get; set; }

        [JsonProperty("recipient")]
        public User Recipient { get; set; }

        [JsonProperty("recipientId")]
        public string RecipientId { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}