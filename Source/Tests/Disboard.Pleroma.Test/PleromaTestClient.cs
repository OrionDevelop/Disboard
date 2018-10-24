using Disboard.Test.Handlers;

namespace Disboard.Pleroma.Test
{
    public class PleromaTestClient
    {
        private const string AccessToken = "TEST_ACCESS_TOKEN";
        private const string ClientId = "xYGFlv-1u4_4gIlxnp2yQqtGAuaO6QDuqtMlBqFmhi0=";
        private const string ClientSecret = "xpwJHsMVztEqlA0Y7Q3wCJ5w9pUjfk9VftVmwe5bm9I=";
        protected PleromaClient TestClient { get; }

        protected PleromaTestClient()
        {
            TestClient = new PleromaClient("pl.smuglo.li", new MockHttpClientHandler())
            {
                ClientId = ClientId,
                ClientSecret = ClientSecret,
                AccessToken = AccessToken
            };
        }
    }
}