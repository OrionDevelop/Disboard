using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models.Streaming
{
    public class WsRestRequestObject : WsRequestObject
    {
        [JsonProperty("ep")]
        public string Ep { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }

        public static WsRestRequest CreateRestRequest(string endpoint, List<KeyValuePair<string, object>> parameters = null)
        {
            return new WsRestRequest
            {
                Body = new WsRestRequestObject
                {
                    Id = Guid.NewGuid().ToString(),
                    Ep = endpoint,
                    Data = parameters == null ? new Dictionary<string, object>() : parameters.ToDictionary(w => w.Key, w => w.Value)
                }
            };
        }
    }
}