using Disboard.Mastodon.Clients;

namespace Disboard.Mastodon
{
    public class MastodonClient : ClientBase
    {
        internal string Domain { get; }

        public MastodonClient(string domain) : base($"https://{domain}", "2.0")
        {
            Domain = domain;

            Account = new AccountsClient(this);
            Apps = new AppsClient(this);
            Auth = new AuthClient(this);
            Blocks = new BlocksClient(this);
            CustomEmojis = new CustomEmojisClient(this);
            Endorsements = new EndorsementsClient(this);
            Favorites = new FavoritesClient(this);
            Instance = new InstanceClient(this);
            Notifications = new NotificationsClient(this);
        }

        // ReSharper disable UnusedAutoPropertyAccessor.Global

        public AccountsClient Account { get; }
        public AppsClient Apps { get; }
        public AuthClient Auth { get; }
        public BlocksClient Blocks { get; }
        public CustomEmojisClient CustomEmojis { get; }
        public EndorsementsClient Endorsements { get; }
        public FavoritesClient Favorites { get; }
        public InstanceClient Instance { get; }
        public NotificationsClient Notifications { get; }

        // ReSharper restore UnusedAutoPropertyAccessor.Global
    }
}