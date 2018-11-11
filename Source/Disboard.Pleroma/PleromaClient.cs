using System.Net.Http;

using Disboard.Mastodon;
using Disboard.Models;
using Disboard.Pleroma.Clients;

using PleromaApi = Disboard.Pleroma.Clients.PleromaClient;

namespace Disboard.Pleroma
{
    public class PleromaClient : MastodonClient
    {
        public PleromaApi Pleroma { get; }
        public new StreamingClient Streaming { get; }

        public PleromaClient(string domain, HttpClientHandler innerHandler = null) : this(new Credential {Domain = domain}, innerHandler) { }

        public PleromaClient(Credential credential, HttpClientHandler innerHandler = null) : base(credential, innerHandler)
        {
            Pleroma = new PleromaApi(this);
            Streaming = new StreamingClient(this);
        }
    }
}