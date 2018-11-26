using System.Net.Http;

using Disboard.Clients;
using Disboard.Models;
using Disboard.PeerTube.Clients;

namespace Disboard.PeerTube
{
    public class PeerTubeClient : AppClient
    {
        public AccountsClient Accounts { get; }
        public OAuthClientsClient OAuthClients { get; }
        public UsersClient Users { get; }

        public PeerTubeClient(string domain, HttpClientHandler innerHandler = null) : this(new Credential {Domain = domain}, innerHandler) { }

        public PeerTubeClient(Credential credential, HttpClientHandler innerHandler = null) : base(credential, new OAuth2HttpClientHandler(innerHandler), RequestMode.FormUrlEncoded)
        {
            Accounts = new AccountsClient(this);
            OAuthClients = new OAuthClientsClient(this);
            Users = new UsersClient(this);
        }
    }
}