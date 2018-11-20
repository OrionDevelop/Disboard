using System;
using System.Collections.Generic;
using System.Linq;

namespace Disboard.Utils
{
    public static class EnumSeparator
    {
        public static IEnumerable<string> Separate<T>(this T flags) where T : Enum
        {
            return flags.ToString().Replace(" ", "").Split(',').Select(w => w.ToLower()).ToList();
        }
    }
}