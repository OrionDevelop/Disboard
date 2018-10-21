using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Exceptions
{
    public class DisboardException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public Uri RequestUri { get; set; }

        public string Response { get; set; }

        private DisboardException(HttpStatusCode status, Uri uri, string response) : base(response)
        {
            StatusCode = status;
            RequestUri = uri;
            Response = response;
        }

        private DisboardException(HttpStatusCode status, Uri uri, string response, string message) : base(message)
        {
            StatusCode = status;
            RequestUri = uri;
            Response = response;
        }

        public static async Task<DisboardException> Create(HttpResponseMessage response, string url)
        {
            var content = await response.Content.ReadAsStringAsync().Stay();
            if (response.Content.Headers.ContentType.MediaType == "application/json")
            {
                // Parse as json
                var json = JsonConvert.DeserializeObject<ApiResponse>(content);

                // 決め打ちよくないけどもー...
                return new DisboardException(response.StatusCode, new Uri(url), content, json.Extends["error"].ToString());
            }

            // unknown, parse as plain text
            return new DisboardException(response.StatusCode, new Uri(url), content);
        }
    }
}