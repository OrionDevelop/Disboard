using System.Threading.Tasks;

using Disboard.Misskey.Enums;

using Xunit;

namespace Disboard.Misskey.Test.Clients.Notes
{
    public class ReactionsClientTest : MisskeyTestClient
    {
        private const string Id = "5bd08d2fcd15d400274a75c4";

        [Fact]
        public async Task CreateAsync()
        {
            await TestClient.Notes.Reactions.CreateAsync(Id, Reaction.Congrats);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            await TestClient.Notes.Reactions.DeleteAsync(Id);
        }
    }
}