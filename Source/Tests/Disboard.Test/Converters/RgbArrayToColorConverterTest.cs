using System.Drawing;

using Disboard.Converters;

using Newtonsoft.Json;

using Xunit;

namespace Disboard.Test.Converters
{
    public class RgbArrayToColorConverterTest
    {
        public class ExpectObject
        {
            [JsonProperty("color")]
            [JsonConverter(typeof(RgbArrayToColorConverter))]
            public Color Color { get; set; }
        }

        [Fact]
        public void ReadJsonInvalidColor()
        {
            const string json = "{\"color\":[0,256,10000]}";
            var r = JsonConvert.DeserializeObject<ExpectObject>(json);
            r.Color.R.Is((byte) 0);
            r.Color.G.Is((byte) 255);
            r.Color.B.Is((byte) 255);
        }

        [Fact]
        public void ReadJsonValidColor()
        {
            const string json = "{\"color\":[125,172,253]}";
            var r = JsonConvert.DeserializeObject<ExpectObject>(json);
            r.Color.R.Is((byte) 125);
            r.Color.G.Is((byte) 172);
            r.Color.B.Is((byte) 253);
        }
    }
}