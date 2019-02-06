using System;
using System.Collections.Generic;

namespace Disboard.Extensions
{
    public static class ListExtensions
    {
        public static void AddIfValidValue<T>(this List<KeyValuePair<string, object>> obj, string key, T value)
        {
            if (value == null)
                return;
            if (value is string str && string.IsNullOrWhiteSpace(str))
                return;

            obj.Add(new KeyValuePair<string, object>(key, value));
        }

        public static void AddIfValidValue<T>(this List<KeyValuePair<string, object>> obj, string key, T? value) where T : struct
        {
            if (!value.HasValue)
                return;
            obj.AddIfValidValue(key, value.Value);
        }

        // default ISO-8601
        public static void AddIfValidValue(this List<KeyValuePair<string, object>> obj, string key, DateTime? value, string format = "O")
        {
            if (!value.HasValue)
                return;
            obj.Add(new KeyValuePair<string, object>(key, value.Value.ToString(format)));
        }

        public static void AddRangeOfValues<T>(this List<KeyValuePair<string, object>> obj, string key, IEnumerable<T> values)
        {
            foreach (var value in values)
                obj.AddIfValidValue(key, value);
        }
    }
}