using System.Collections.Generic;

using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class Deck : ApiResponse
    {
        [JsonProperty("columns")]
        public IEnumerable<DeckColumn> Columns { get; set; }

        [JsonProperty("layout")]
        public IEnumerable<IEnumerable<string>> Layout { get; set; }
    }
}