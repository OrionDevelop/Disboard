using System;

namespace Disboard.Mastodon.Enums
{
    [Flags]
    public enum FilterContext
    {
        Home = 1 << 0,

        Notifications = 1 << 1,

        Public = 1 << 2,

        Thread = 1 << 3
    }
}