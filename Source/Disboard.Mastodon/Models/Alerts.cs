using Disboard.Models;

namespace Disboard.Mastodon.Models
{
    public class Alerts : ApiResponse
    {
        public bool Follow { get; set; }

        public bool Favourite { get; set; }

        public bool Reblog { get; set; }

        public bool Mention { get; set; }
    }
}