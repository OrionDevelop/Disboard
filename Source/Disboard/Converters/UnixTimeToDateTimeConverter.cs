using System;

using Newtonsoft.Json;

namespace Disboard.Converters
{
    /// <summary>
    ///     123456789 to DateTime
    /// </summary>
    public class UnixTimeToDateTimeConverter : JsonConverter
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = reader.Value;
            if (int.TryParse(value.ToString(), out var i))
                return Epoch.AddSeconds(i);
            if (long.TryParse(value.ToString(), out var l))
                return Epoch.AddMilliseconds(l);
            if (!int.TryParse(reader.Value.ToString(), out _) && long.TryParse(reader.Value.ToString(), out l))
                return Epoch.AddMilliseconds(l);
            return Epoch.AddSeconds(long.Parse(reader.Value as string ?? throw new InvalidOperationException()));
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}