namespace Disboard.Misskey.Enums
{
    public enum Permission
    {
        AccountRead = 0,

        AccountWrite = 1,

        DriveRead = 1 << 1,

        DriveWrite = 1 << 2,

        FavoritesRead = 1 << 3,

        FavoriteWrite = 1 << 4,

        FollowingRead = 1 << 5,

        FollowingWrite = 1 << 6,

        MessagingRead = 1 << 7,

        MessagingWrite = 1 << 8,

        NoteWrite = 1 << 9,

        NotificationWrite = 1 << 10,

        ReactionWrite = 1 << 11,

        VoteWrite = 1 << 12,

        // old?
        AccountRead2 = 1 << 13,

        AccountWrite2 = 1 << 14
    }
}