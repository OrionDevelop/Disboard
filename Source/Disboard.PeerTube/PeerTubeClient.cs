using System.Net.Http;

using Disboard.Clients;
using Disboard.Models;

namespace Disboard.PeerTube
{
    public class PeerTubeClient : AppClient
    {
        public PeerTubeClient(string domain, HttpClientHandler innerHandler = null) : base(domain, new OAuth2HttpClientHandler(innerHandler), RequestMode.Json) { }
    }
}