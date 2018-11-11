using System.Linq;
using System.Threading.Tasks;

using Disboard.Test.Helpers;

using Xunit;

namespace Disboard.Misskey.Test.Clients
{
    public class NotesClientTest : MisskeyTestClient
    {
        [Fact]
        public async Task ConversationAsync()
        {
            var actual = await TestClient.Notes.ConversationAsync("5bd08d2fcd15d400274a75c4", 1, 0);
            actual.Count.Is(1);
            actual.First().CheckRecursively(IgnoreProperties);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var actual = await TestClient.Notes.CreateAsync("てすと", "public", viaMobile: true, cw: "cw");
            actual.CheckRecursively();
        }

        [Fact]
        public async Task DeleteAsync()
        {
            await TestClient.Notes.DeleteAsync("5bd4b1c1c04afd004352ca62");
        }

        [Fact]
        public async Task FeaturedAsync()
        {
            var actual = await TestClient.Notes.FeaturedAsync(1);
            actual.Count.Is(1);
            actual.First().CheckRecursively(IgnoreProperties);
        }

        [Fact]
        public async Task GlobalTimelineAsync()
        {
            var actual = await TestClient.Notes.GlobalTimelineAsync(1, true);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task HybridTimelineAsync()
        {
            var actual = await TestClient.Notes.HybridTimelineAsync(1, false, false, false, true);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task LocalTimelineAsync()
        {
            var actual = await TestClient.Notes.LocalTimelineAsync(1, true, null, true);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task MentionsAsync()
        {
            var actual = await TestClient.Notes.MentionsAsync(1, false, "public");
            actual.Count.Is(1);
            actual.First().CheckRecursively(IgnoreProperties);
        }

        [Fact]
        public async Task ReactionsAsync()
        {
            var actual = await TestClient.Notes.ReactionsAsync("5bd41adc642d73004c74217b", 1, 0);
            actual.Count.Is(1);
            actual.First().CheckRecursively(IgnoreProperties);
        }

        [Fact]
        public async Task RepliesAsync()
        {
            var actual = await TestClient.Notes.RepliesAsync("5bd08d2d16e0bd002ee322ff", 1, 0);
            actual.Count.Is(1);
            actual.First().CheckRecursively(IgnoreProperties);
        }

        [Fact]
        public async Task RepostsAsync()
        {
            var actual = await TestClient.Notes.RepostsAsync("5bd45f46927d0f0021487e01", 1);
            actual.Count.Is(1);
            actual.First().CheckRecursively(IgnoreProperties);
        }

        [Fact]
        public async Task SearchAsync()
        {
            var actual = await TestClient.Notes.SearchAsync("Misskey", 1, 0);
            actual.Count.Is(1);
            actual.First().CheckRecursively(IgnoreProperties);
        }

        [Fact]
        public async Task SearchByTagAsync()
        {
            var actual = await TestClient.Notes.SearchByTagAsync("Misskey", mute: "mute_all", following: false, reply: false, renote: false, limit: 1);
            actual.Count.Is(1);
            actual.First().CheckRecursively(IgnoreProperties);
        }

        [Fact]
        public async Task ShowAsync()
        {
            var actual = await TestClient.Notes.ShowAsync("5bd4bac6b3ab3a002178d042");
            actual.CheckRecursively(IgnoreProperties);
        }

        [Fact]
        public async Task TimelineAsync()
        {
            var actual = await TestClient.Notes.TimelineAsync(1, null, null, null, null, false, false, true);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact(Skip = "No Trends?")]
        public async Task TrendAsync()
        {
            var actual = await TestClient.Notes.TrendAsync(1, 0);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }

        [Fact]
        public async Task UserListTimelineAsync()
        {
            var actual = await TestClient.Notes.UserListTimelineAsync("5bd5451d27711d00457b5984", 1, includeMyRenotes: false, includeRenotedMyNotes: false, includeLocalRenotes: false);
            actual.Count.Is(1);
            actual.First().CheckRecursively();
        }
    }
}