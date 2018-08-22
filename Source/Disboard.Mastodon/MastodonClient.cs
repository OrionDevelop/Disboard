using Disboard.Mastodon.Clients;

namespace Disboard.Mastodon
{
    public class MastodonClient : ClientBase
    {
        public AppsClient Apps { get; }
        public AuthClient Auth { get; }

        internal string Domain { get; }

        public MastodonClient(string domain) : base($"https://{domain}", "2.0")
        {
            Domain = domain;

            Apps = new AppsClient(this);
            Auth = new AuthClient(this);
        }
    }
}