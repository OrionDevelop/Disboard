using System;

using Disboard.Converters;

using Newtonsoft.Json;

using Xunit;

namespace Disboard.Test.Converters
{
    public class UnixTimeToDateTimeConverterTest
    {
        public class ExpectObject
        {
            [JsonProperty("createdAt")]
            [JsonConverter(typeof(UnixTimeToDateTimeConverter))]
            public DateTime CreatedAt { get; set; }
        }

        [Fact]
        public void ReadJsonMillSecondsByLong()
        {
            const string json = "{\"createdAt\":1540120526120}";
            var r = JsonConvert.DeserializeObject<ExpectObject>(json);
            r.CreatedAt.Is(new DateTime(2018, 10, 21, 11, 15, 26, 120, DateTimeKind.Utc));
        }

        [Fact]
        public void ReadJsonMillSecondsByString()
        {
            const string json = "{\"createdAt\":\"1540120526120\"}";
            var r = JsonConvert.DeserializeObject<ExpectObject>(json);
            r.CreatedAt.Is(new DateTime(2018, 10, 21, 11, 15, 26, 120, DateTimeKind.Utc));
        }

        [Fact]
        public void ReadJsonSecondsByLong()
        {
            const string json = "{\"createdAt\":1540120526}";
            var r = JsonConvert.DeserializeObject<ExpectObject>(json);
            r.CreatedAt.Is(new DateTime(2018, 10, 21, 11, 15, 26, DateTimeKind.Utc));
        }

        [Fact]
        public void ReadJsonSecondsByString()
        {
            const string json = "{\"createdAt\":\"1540120526\"}";
            var r = JsonConvert.DeserializeObject<ExpectObject>(json);
            r.CreatedAt.Is(new DateTime(2018, 10, 21, 11, 15, 26, DateTimeKind.Utc));
        }
    }
}