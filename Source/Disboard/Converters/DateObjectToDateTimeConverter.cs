using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Disboard.Converters
{
    /// <summary>
    ///     {"year": 2018, "month": 10, "day": 19} to DateTime
    /// </summary>
    public class DateObjectToDateTimeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.StartObject)
                throw new NotSupportedException();

            var dictionary = new Dictionary<string, int>();
            var key = "";

            while (reader.Read() && reader.TokenType != JsonToken.EndObject)
                switch (reader.TokenType)
                {
                    case JsonToken.PropertyName:
                        key = reader.Value.ToString();
                        break;

                    case JsonToken.Integer:
                        var value = int.Parse(reader.Value.ToString());
                        if (string.IsNullOrWhiteSpace(key))
                            throw new NotSupportedException();
                        dictionary[key] = value;
                        break;
                }
            return new DateTime(dictionary["year"], dictionary["month"], dictionary["day"]);
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}