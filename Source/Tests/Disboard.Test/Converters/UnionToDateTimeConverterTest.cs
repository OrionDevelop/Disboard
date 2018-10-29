using System;

using Disboard.Converters;

using Newtonsoft.Json;

using Xunit;

namespace Disboard.Test.Converters
{
    public class UnionToDateTimeConverterTest
    {
        public class ExpectObject
        {
            [JsonProperty("createdAt")]
            [JsonConverter(typeof(UnionToDateTimeConverter))]
            public DateTime CreatedAt { get; set; }
        }

        [Fact]
        public void ReadJsonDateObject()
        {
            const string json = "{\"createdAt\":{\"year\":2018,\"month\":12,\"day\":11}}";
            var r = JsonConvert.DeserializeObject<ExpectObject>(json);

            r.CreatedAt.Year.Is(2018);
            r.CreatedAt.Month.Is(12);
            r.CreatedAt.Day.Is(11);
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
        public void ReadJsonNull()
        {
            const string json = "{\"createdAt\":null}";
            var r = JsonConvert.DeserializeObject<ExpectObject>(json);
            r.CreatedAt.Is(DateTime.MinValue);
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