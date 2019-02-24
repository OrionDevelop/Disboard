using Disboard.Models;

using Newtonsoft.Json.Linq;

namespace Disboard.Misskey.Models.Streaming
{
    public class UnknownMessage : IStreamMessage
    {
        public JToken Body { get; set; }
    }
}