using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Disboard.Clients
{
    public class OAuth2HttpClientHandler : DisboardHttpHandler
    {
        public OAuth2HttpClientHandler(HttpClientHandler innerHandler = null) : base(innerHandler) { }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(Client.AccessToken))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Client.AccessToken);
            return base.SendAsync(request, cancellationToken);
        }
    }
}