using System.Collections.Generic;
using System.Threading.Tasks;

using Xunit;

namespace Disboard.Pleroma.Test.Clients
{
    public class PleromaClientTest : PleromaTestClient
    {
        [Fact]
        public async Task EmojiAsync()
        {
            var actual = await TestClient.Pleroma.EmojiAsync();
            actual.Count.Is(187);
            actual.IsInstanceOf<Dictionary<string, string>>();
        }

        [Fact(Skip = "FIXME")]
        public async Task FollowImport()
        {
            await TestClient.Pleroma.FollowImport(new List<string> {"1"});
        }
    }
}