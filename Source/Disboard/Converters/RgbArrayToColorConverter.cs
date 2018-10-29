using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Newtonsoft.Json;

namespace Disboard.Converters
{
    /// <summary>
    ///     [r, g, b] to Color
    /// </summary>
    public class RgbArrayToColorConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            if (reader.TokenType != JsonToken.StartArray)
                throw new NotSupportedException();

            var array = new List<int>();
            while (reader.Read() && reader.TokenType == JsonToken.Integer)
                if (reader.Value is long l)
                    array.Add((int) l);
                else
                    throw new NotSupportedException();

            // XXX: たまーに 255 の範囲を超えるものが来る
            array = array.Select(w => w >= 255 ? 255 : w).ToList();
            return Color.FromArgb(array[0], array[1], array[2]);
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}