using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using Newtonsoft.Json;

namespace Disboard.Converters
{
    /// <summary>
    ///     ["flagA", "flagB"] to { FlagA, FlagB }
    /// </summary>
    public class StringFlagConverter : JsonConverter
    {
        private static readonly MethodInfo Parse = typeof(Enum).GetMethod("Parse", new[] {typeof(Type), typeof(string)});

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var innerType = objectType.GenericTypeArguments[0];
            if (reader.Value is string flags)
                if (Activator.CreateInstance(typeof(List<>).MakeGenericType(innerType)) is IList list)
                {
                    foreach (var flag in flags.Split(' '))
                        list.Add(Parse.Invoke(null, new object[] {innerType, flag.Substring(0, 1).ToUpper() + flag.Substring(1)}));
                    return list;
                }
            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}