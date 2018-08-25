using System;

namespace Disboard.Mastodon.Enums
{
    [Flags]
    public enum AccessScope
    {
        Read = 0,

        Write = 1 << 0,

        Follow = 1 << 1
    }
}