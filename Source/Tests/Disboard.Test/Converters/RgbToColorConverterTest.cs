using System.Drawing;

using Disboard.Converters;

using Newtonsoft.Json;

using Xunit;

namespace Disboard.Test.Converters
{
    public class RgbToColorConverterTest
    {
        public class ExpectObject
        {
            [JsonProperty("color")]
            [JsonConverter(typeof(RgbToColorConverter))]
            public Color Color { get; set; }
        }

        [Fact]
        public void ReadJsonInvalidColor()
        {
            const string json = "{\"color\":\"rgb(0,255,255)\"}";
            var r = JsonConvert.DeserializeObject<ExpectObject>(json);
            r.Color.R.Is((byte) 0);
            r.Color.G.Is((byte) 255);
            r.Color.B.Is((byte) 255);
        }

        [Fact]
        public void ReadJsonValidColor()
        {
            const string json = "{\"color\":\"rgb(125,172,253)\"}";
            var r = JsonConvert.DeserializeObject<ExpectObject>(json);
            r.Color.R.Is((byte) 125);
            r.Color.G.Is((byte) 172);
            r.Color.B.Is((byte) 253);
        }
    }
}