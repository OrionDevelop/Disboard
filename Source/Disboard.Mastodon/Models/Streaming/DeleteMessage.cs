using Disboard.Models;

namespace Disboard.Mastodon.Models.Streaming
{
    public class DeleteMessage : IStreamMessage
    {
        public long Id { get; set; }
    }
}