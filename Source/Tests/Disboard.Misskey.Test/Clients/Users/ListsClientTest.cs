using System.Linq;
using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Misskey.Test.Clients.Users
{
    public class ListsClientTest : MisskeyTestClient
    {
        private const string Id = "5bd5451d27711d00457b5984";

        [Fact]
        public async Task CreateAsync()
        {
            var actual = await TestClient.Users.Lists.CreateAsync("Disboard.Test");
            actual.CheckRecursively();
        }

        [Fact]
        public async Task DeleteAsync()
        {
            await TestClient.Users.Lists.DeleteAsync(Id);
        }

        [Fact]
        public async Task ListAsync()
        {
            var actual = await TestClient.Users.Lists.ListAsync();
            actual.Count.IsNot(0);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task PushAsync()
        {
            await TestClient.Users.Lists.PushAsync(Id, "5ba4c40406bdd21ada87964b");
        }

        [Fact]
        public async Task ShowAsync()
        {
            await TestClient.Users.Lists.ShowAsync(Id);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            await TestClient.Users.Lists.UpdateAsync(Id, "Disboard.Tested");
        }
    }
}