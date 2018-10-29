using Disboard.Models;

namespace Disboard.Mastodon.Models
{
    public class Keys : ApiResponse
    {
        // ReSharper disable once InconsistentNaming
        public string P256DH { get; set; }

        public string Auth { get; set; }
    }
}