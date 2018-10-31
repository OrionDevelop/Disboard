using Disboard.Test.Handlers;

namespace Disboard.PeerTube.Test
{
    public class PeerTubeTestClient
    {
        protected PeerTubeClient TestClient { get; }

        public PeerTubeTestClient()
        {
            TestClient = new PeerTubeClient("peertube.social", new MockHttpClientHandler())
            {
                ClientId = "95oj3g3c2wcyjaj7gbwzyvwc6xblmull",
                ClientSecret = "Qq7jprMvMZBSNJZ8pULAfaHPJkHsRE7H"
            };
        }
    }
}