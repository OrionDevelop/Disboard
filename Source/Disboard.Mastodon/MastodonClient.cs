using System.Collections.Generic;
using System.Net.Http;

using Disboard.Clients;
using Disboard.Mastodon.Clients;
using Disboard.Models;

namespace Disboard.Mastodon
{
    public class MastodonClient : AppClient
    {
        public MastodonClient(string domain, HttpClientHandler innerHandler = null) : this(new Credential { Domain = domain }, innerHandler) { }

        public MastodonClient(Credential credential, HttpClientHandler innerHandler = null) : base(credential, new OAuth2HttpClientHandler(innerHandler), RequestMode.FormUrlEncoded)
        {
            BinaryParameters = new List<string> { "avatar", "header", "file" };

            Account = new AccountsClient(this);
            Apps = new AppsClient(this);
            Auth = new AuthClient(this);
            Blocks = new BlocksClient(this);
            Conversations = new ConversationsClient(this);
            CustomEmojis = new CustomEmojisClient(this);
            DomainBlocks = new DomainBlocksClient(this);
            Endorsements = new EndorsementsClient(this);
            Favorites = new FavoritesClient(this);
            Filters = new FiltersClient(this);
            FollowRequests = new FollowRequestsClient(this);
            Follows = new FollowsClient(this);
            Instance = new InstanceClient(this);
            Lists = new ListsClient(this);
            Media = new MediaClient(this);
            Notifications = new NotificationsClient(this);
            Push = new PushClient(this);
            Reports = new ReportsClient(this);
            ScheduledStatuses = new ScheduledStatusesClient(this);
            SearchV1 = new SearchV1Client(this);
            SearchV2 = new SearchV2Client(this);
            Statuses = new StatusesClient(this);
            Streaming = new StreamingClient(this);
            Suggestions = new SuggestionsClient(this);
            Timelines = new TimelinesClient(this);
        }

        // ReSharper disable UnusedAutoPropertyAccessor.Global

        public AccountsClient Account { get; }
        public AppsClient Apps { get; }
        public AuthClient Auth { get; }
        public BlocksClient Blocks { get; }
        public ConversationsClient Conversations { get; }
        public CustomEmojisClient CustomEmojis { get; }
        public DomainBlocksClient DomainBlocks { get; }
        public EndorsementsClient Endorsements { get; }
        public FavoritesClient Favorites { get; }
        public FiltersClient Filters { get; }
        public FollowRequestsClient FollowRequests { get; }
        public FollowsClient Follows { get; }
        public InstanceClient Instance { get; }
        public ListsClient Lists { get; }
        public MediaClient Media { get; }
        public NotificationsClient Notifications { get; }
        public PushClient Push { get; }
        public ReportsClient Reports { get; }
        public ScheduledStatusesClient ScheduledStatuses { get; }
        public SearchV1Client SearchV1 { get; }
        public SearchV2Client SearchV2 { get; }
        public StatusesClient Statuses { get; }
        public StreamingClient Streaming { get; }
        public SuggestionsClient Suggestions { get; }
        public TimelinesClient Timelines { get; }

        // ReSharper restore UnusedAutoPropertyAccessor.Global
    }
}