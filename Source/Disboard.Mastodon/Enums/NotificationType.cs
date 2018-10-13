using System;

namespace Disboard.Mastodon.Enums
{
    [Flags]
    public enum NotificationType
    {
        Mention = 0,

        Reblog = 1 << 0,

        Favourite = 1 << 2,

        Follow = 1 << 3
    }
}