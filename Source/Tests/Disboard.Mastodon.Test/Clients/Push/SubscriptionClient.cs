using System.Threading.Tasks;

using Xunit;

namespace Disboard.Mastodon.Test.Clients.Push
{
    public class SubscriptionClient
    {
        [Fact(Skip = "Not used in client application")]
        public Task CreateAsync()
        {
            return Task.CompletedTask;
        }
    }
}