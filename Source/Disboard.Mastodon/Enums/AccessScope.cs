using System;

namespace Disboard.Mastodon.Enums
{
    [Flags]
    public enum AccessScope
    {
        Read = 0x0001,

        Write = 0x0002,

        Follow = 0x0004
    }
}