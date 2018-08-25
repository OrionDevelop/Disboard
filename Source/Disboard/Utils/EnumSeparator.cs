using System.Collections.Generic;
using System.Linq;

namespace Disboard.Utils
{
    public static class EnumSeparator
    {
        public static List<string> Separate<T>(T flags)
        {
            return flags.ToString().Replace(" ", "").Split(',').Select(w => w.ToLower()).ToList();
        }
    }
}