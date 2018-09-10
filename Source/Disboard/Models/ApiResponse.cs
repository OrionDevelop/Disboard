using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Disboard.Models
{
    public class ApiResponse
    {
        [JsonExtensionData]
        public IDictionary<string, JToken> Extends { get; set; }
    }
}