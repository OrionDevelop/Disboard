using System;

using Disboard.Misskey.Enums;

namespace Disboard.Misskey.Extensions
{
    public static class PermissionExtensions
    {
        public static string ToStr(this Permission permission)
        {
            switch (permission)
            {
                case Permission.AccountRead:
                    return "account-read";

                case Permission.AccountWrite:
                    return "account-write";

                case Permission.DriveRead:
                    return "drive-read";

                case Permission.DriveWrite:
                    return "drive-write";

                case Permission.FavoritesRead:
                    return "favorites-read";

                case Permission.FavoritesWrite:
                    return "favorites-write";

                case Permission.FollowingWrite:
                    return "following-write";

                case Permission.FollowingRead:
                    return "following-read";

                case Permission.MessagingRead:
                    return "messaging-read";

                case Permission.MessagingWrite:
                    return "messaging-write";

                case Permission.NoteWrite:
                    return "note-write";

                case Permission.NotificationWrite:
                    return "notification-write";

                case Permission.ReactionWrite:
                    return "reaction-write";

                case Permission.VoteWrite:
                    return "vote-write";

                case Permission.AccountRead2:
                    return "account/read";

                case Permission.AccountWrite2:
                    return "account/write";

                default:
                    throw new ArgumentOutOfRangeException(nameof(permission), permission, null);
            }
        }
    }
}