using Disboard.Test.Handlers;

namespace Disboard.Misskey.Test
{
    public class MisskeyTestClient
    {
        private const string AccessToken = "";
        private const string ClientSecret = "";

        protected MisskeyClient TestClient { get; }

        protected MisskeyTestClient()
        {
            TestClient = new MisskeyClient("misskey.xyz", new MockHttpClientHandler())
            {
                ClientSecret = ClientSecret,
                AccessToken = AccessToken
            };
        }
    }
}