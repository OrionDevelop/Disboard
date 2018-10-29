using System.Collections.Generic;
using System.Linq;

using Disboard.Converters;

using Newtonsoft.Json;

using Xunit;

namespace Disboard.Test.Converters
{
    public class StringFlagConverterTest
    {
        public enum Scope
        {
            Read = 1 << 0,

            Write = 1 << 1
        }

        public class ExpectObject
        {
            [JsonProperty("scopes")]
            [JsonConverter(typeof(StringFlagConverter))]
            public IEnumerable<Scope> Scopes { get; set; }
        }

        [Fact]
        public void ReadJsonMulti()
        {
            const string json = "{\"scopes\":\"read write\"}";
            var r = JsonConvert.DeserializeObject<ExpectObject>(json);
            var scopes = (List<Scope>) r.Scopes;
            scopes.Count.Is(2);
            scopes[0].Is(Scope.Read);
            scopes[1].Is(Scope.Write);
        }

        [Fact]
        public void ReadJsonSingle()
        {
            const string json = "{\"scopes\":\"read\"}";
            var r = JsonConvert.DeserializeObject<ExpectObject>(json);
            r.Scopes.Count().Is(1);
            r.Scopes.First().Is(Scope.Read);
        }
    }
}