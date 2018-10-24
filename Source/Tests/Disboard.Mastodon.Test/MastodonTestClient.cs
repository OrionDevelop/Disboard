using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Disboard.Test.Handlers;

namespace Disboard.Mastodon.Test
{
    public class MastodonTestClient
    {
        private const string AccessToken = "TEST_ACCESS_TOKEN";
        private const string ClientId = "08b26d89391544984b9a23d95f3a4c91b2f7cdfff7775a7452f7c1cb6c6c048d";
        private const string ClientSecret = "55d24a5f4f480d26fa02d7e96b8b879b0a0853fa6d76c6861272b231f4eee81b";
        protected MastodonClient TestClient { get; }

        protected MastodonTestClient()
        {
            TestClient = new MastodonClient("mastodon.cloud", new MockHttpClientHandler())
            {
                ClientId = ClientId,
                ClientSecret = ClientSecret,
                AccessToken = AccessToken
            };
        }

        protected async Task MarkAsAnother(Func<MastodonClient, Task> asyncAction, [CallerMemberName] string caller = "salt")
        {
            var client = new MastodonClient("mastodon.cloud", new MockHttpClientHandler($"salt-{caller}"))
            {
                ClientId = ClientId,
                ClientSecret = ClientSecret,
                AccessToken = AccessToken
            };
            await asyncAction.Invoke(client);
        }
    }
}