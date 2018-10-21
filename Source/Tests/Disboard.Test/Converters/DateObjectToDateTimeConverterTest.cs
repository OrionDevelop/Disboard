using System;

using Disboard.Converters;

using Newtonsoft.Json;

using Xunit;

namespace Disboard.Test.Converters
{
    public class DateObjectToDateTimeConverterTest
    {
        public class ExpectObject
        {
            [JsonProperty("createdAt")]
            [JsonConverter(typeof(DateObjectToDateTimeConverter))]
            public DateTime CreatedAt { get; set; }
        }

        [Fact]
        public void ReadJson()
        {
            const string json = "{\"createdAt\":{\"year\":2018,\"month\":12,\"day\":11}}";
            var r = JsonConvert.DeserializeObject<ExpectObject>(json);

            r.CreatedAt.Year.Is(2018);
            r.CreatedAt.Month.Is(12);
            r.CreatedAt.Day.Is(11);
        }
    }
}