using Disboard.Test.Handlers;

namespace Disboard.PeerTube.Test
{
    public class PeerTubeTestClient
    {
        protected PeerTubeClient TestClient { get; }

        public PeerTubeTestClient()
        {
            TestClient = new PeerTubeClient("peertube.social", new MockHttpClientHandler());
        }
    }
}