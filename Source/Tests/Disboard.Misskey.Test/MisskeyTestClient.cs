using System;

using Disboard.Test.Handlers;

namespace Disboard.Misskey.Test
{
    public class MisskeyTestClient
    {
#if DEBUG
        protected const string AccessToken = "TEST_ACCESS_TOKEN";
        protected const string ClientSecret = "TEST_CLIENT_SECRET";
#else
        protected readonly string AccessToken = Environment.GetEnvironmentVariable("MISSKEY_ACCESS_TOKEN");
        protected readonly string ClientSecret = Environment.GetEnvironmentVariable("MISSKEY_CLIENT_SECRET");
#endif
        protected MisskeyClient TestClient { get; }
        protected string[] IgnoreProperties = {"two_factor_temp_secret", "_follower", "_followee", "_replyIds", "_quoteIds", "_user"};

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