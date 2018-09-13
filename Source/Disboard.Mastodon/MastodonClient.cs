using System.Collections.Generic;

using Disboard.Mastodon.Clients;

namespace Disboard.Mastodon
{
    public class MastodonClient : AppClient
    {
        internal string Domain { get; }

        public MastodonClient(string domain) : base($"https://{domain}", "2.0")
        {
            Domain = domain;
            BinaryParameters = new List<string> {"avatar", "header", "file"};

            Account = new AccountsClient(this);
            Apps = new AppsClient(this);
            Auth = new AuthClient(this);
            Blocks = new BlocksClient(this);
            CustomEmojis = new CustomEmojisClient(this);
            DomainBlocks = new DomainBlocksClient(this);
            Endorsements = new EndorsementsClient(this);
            Favorites = new FavoritesClient(this);
            Filters = new FiltersClient(this);
            Follows = new FollowsClient(this);
            Instance = new InstanceClient(this);
            Lists = new ListsClient(this);
            Media = new MediaClient(this);
            Notifications = new NotificationsClient(this);
            SearchV1 = new SearchV1Client(this);
            Statuses = new StatusesClient(this);
            Suggestions = new SuggestionsClient(this);
            Timelines = new TimelinesClient(this);
        }

        // ReSharper disable UnusedAutoPropertyAccessor.Global

        public AccountsClient Account { get; }
        public AppsClient Apps { get; }
        public AuthClient Auth { get; }
        public BlocksClient Blocks { get; }
        public CustomEmojisClient CustomEmojis { get; }
        public DomainBlocksClient DomainBlocks { get; }
        public EndorsementsClient Endorsements { get; }
        public FavoritesClient Favorites { get; }
        public FiltersClient Filters { get; }
        public FollowsClient Follows { get; }
        public InstanceClient Instance { get; }
        public ListsClient Lists { get; }
        public MediaClient Media { get; }
        public NotificationsClient Notifications { get; }
        public SearchV1Client SearchV1 { get; }
        public StatusesClient Statuses { get; }
        public SuggestionsClient Suggestions { get; }
        public TimelinesClient Timelines { get; }

        // ReSharper restore UnusedAutoPropertyAccessor.Global
    }
}