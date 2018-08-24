using Disboard.Mastodon.Clients;

namespace Disboard.Mastodon
{
    public class MastodonClient : ClientBase
    {
        public AccountsClient Account { get; }
        public AppsClient Apps { get; }
        public AuthClient Auth { get; }

        internal string Domain { get; }

        public MastodonClient(string domain) : base($"https://{domain}", "2.0")
        {
            Domain = domain;

            Account = new AccountsClient(this);
            Apps = new AppsClient(this);
            Auth = new AuthClient(this);
        }
    }
}