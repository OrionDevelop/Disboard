using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Disboard.Misskey.Handlers
{
    public class MisskeyAuthenticationHandler : DisboardHttpHandler
    {
        public MisskeyAuthenticationHandler(HttpClientHandler innerHandler = null) : base(innerHandler) { }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(Client.AccessToken))
                return await base.SendAsync(request, cancellationToken).Stay();

            var content = request.Content;
            if (request.Content.Headers.ContentType.MediaType == "application/json")
            {
                // json
                var json = JsonConvert.DeserializeObject<ApiResponse>(await content.ReadAsStringAsync().Stay());
                if (json.Extends == null)
                    json.Extends = new Dictionary<string, JToken>();
                json.Extends["i"] = ((MisskeyClient) Client).EncryptedAccessToken;
                request.Content = new StringContent(JsonConvert.SerializeObject(json.Extends), Encoding.UTF8, "application/json");
            }
            else
            {
                // form-encoded
                ((MultipartFormDataContent) content).Add(new StringContent(((MisskeyClient) Client).EncryptedAccessToken), "i");
                request.Content = content;
            }
            return await base.SendAsync(request, cancellationToken).Stay();
        }
    }
}