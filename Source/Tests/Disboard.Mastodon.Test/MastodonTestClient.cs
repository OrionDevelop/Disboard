using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

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