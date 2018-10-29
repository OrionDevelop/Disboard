using System.Net;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Disboard.Test.Models
{
    public class HttpResponse
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public HttpStatusCode StatusCode { get; set; }

        public string Body { get; set; }
    }
}