using System.Net.Http;

using Disboard.Clients;
using Disboard.Models;
using Disboard.PeerTube.Clients;

namespace Disboard.PeerTube
{
    public class PeerTubeClient : AppClient
    {
        public OAuthClientsClient OAuthClients { get; }

        public PeerTubeClient(string domain, HttpClientHandler innerHandler = null) : base(domain, new OAuth2HttpClientHandler(innerHandler), RequestMode.Json)
        {
            OAuthClients = new OAuthClientsClient(this);
        }
    }
}