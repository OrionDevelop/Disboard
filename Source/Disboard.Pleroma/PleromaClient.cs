using Disboard.Mastodon;
using Disboard.Pleroma.Clients;

using PleromaApi = Disboard.Pleroma.Clients.PleromaClient;

namespace Disboard.Pleroma
{
    public class PleromaClient : MastodonClient
    {
        public PleromaApi Pleroma { get; }
        public new StreamingClient Streaming { get; }

        public new string Domain => base.Domain;

        public PleromaClient(string domain) : base(domain)
        {
            Pleroma = new PleromaApi(this);
            Streaming = new StreamingClient(this);
        }
    }
}