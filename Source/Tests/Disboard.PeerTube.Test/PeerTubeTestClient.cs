using Disboard.Test.Handlers;

namespace Disboard.PeerTube.Test
{
    public class PeerTubeTestClient
    {
        protected PeerTubeClient TestClient { get; }

        public PeerTubeTestClient()
        {
            TestClient = new PeerTubeClient("peertube.fr", new MockHttpClientHandler())
            {
                ClientId = "3kwswtkq376e1yazulftgkmt2zjw27fk",
                ClientSecret = "X7tNQi7EYMbVkj6PhTJBJVYDxmRlSEQU"
            };
        }
    }
}