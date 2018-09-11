using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Disboard.Models
{
    public class ApiResponse
    {
        // This property should be null.
        [JsonExtensionData]
        public IDictionary<string, JToken> Extends { get; set; }
    }
}