using Disboard.Mastodon.Clients;

namespace Disboard.Mastodon
{
    public class MastodonClient : ClientBase
    {
        public AppsClient Apps { get; }

        public MastodonClient(string domain) : base($"https://{domain}", "2.0")
        {
            Apps = new AppsClient(this);
        }
    }
}