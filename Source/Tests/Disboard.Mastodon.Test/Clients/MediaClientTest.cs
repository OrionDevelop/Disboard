using System.Drawing;
using System.IO;
using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Mastodon.Test.Clients
{
    public class MediaClientTest : MastodonTestClient
    {
        private const long Id = 8859990;

        [Fact(Skip = "Hashed-Key is indeterminate")]
        public async Task CreateAsync()
        {
            var media = Path.Combine("./", "data", "photo.jpg");
            var actual = await TestClient.Media.CreateAsync(media, "Beautiful Night", Point.Empty);
            actual.CheckRecursively();
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var actual = await TestClient.Media.UpdateAsync(Id, "Good Night", Point.Empty);
            actual.Description.Is("Good Night");
            actual.CheckRecursively();
        }
    }
}