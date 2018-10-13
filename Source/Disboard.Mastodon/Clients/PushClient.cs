using Disboard.Clients;
using Disboard.Mastodon.Clients.Push;

namespace Disboard.Mastodon.Clients
{
    public class PushClient : ApiClient<MastodonClient>
    {
        public SubscriptionClient Subscription { get; }

        protected internal PushClient(MastodonClient client) : base(client, "")
        {
            Subscription = new SubscriptionClient(client);
        }
    }
}