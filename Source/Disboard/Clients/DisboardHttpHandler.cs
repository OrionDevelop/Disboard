using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Disboard.Clients
{
    public class DisboardHttpHandler : DelegatingHandler
    {
        // ReSharper disable once MemberCanBeProtected.Global
        protected internal AppClient Client { get; internal set; }

        protected DisboardHttpHandler(HttpClientHandler innerHandler = null) : base(innerHandler ?? new HttpClientHandler()) { }
    }
}