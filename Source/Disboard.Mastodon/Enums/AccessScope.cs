using System;

namespace Disboard.Mastodon.Enums
{
    [Flags]
    public enum AccessScope
    {
        Read = 1 << 0,

        Write = 1 << 1,

        Follow = 1 << 2
    }
}