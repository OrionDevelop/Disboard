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
    }
}