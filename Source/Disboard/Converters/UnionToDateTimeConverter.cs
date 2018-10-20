using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Disboard.Converters
{
    /// <summary>
    ///     IsoDateTime, UnixTime, {year, month, day} to DateTime
    /// </summary>
    public class UnionToDateTimeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
                return DateTime.MinValue;
            if (reader.TokenType == JsonToken.StartObject)
                return new DateObjectToDateTimeConverter().ReadJson(reader, objectType, existingValue, serializer);
            return reader.TokenType == JsonToken.Integer
                ? new UnixTimeToDateTimeConverter().ReadJson(reader, objectType, existingValue, serializer)
                : new IsoDateTimeConverter().ReadJson(reader, objectType, existingValue, serializer);
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}