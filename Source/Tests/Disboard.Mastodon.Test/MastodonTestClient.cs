using Disboard.Test.Handlers;

namespace Disboard.Mastodon.Test
{
    public class MastodonTestClient
    {
        protected MastodonClient TestClient { get; }

        protected MastodonTestClient()
        {
            TestClient = new MastodonClient("mastodon.cloud", new MockHttpClientHandler())
            {
            };
        }
    }
}