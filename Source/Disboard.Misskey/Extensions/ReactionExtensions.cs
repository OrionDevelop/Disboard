using System;

using Disboard.Misskey.Enums;

namespace Disboard.Misskey.Extensions
{
    public static class ReactionExtensions
    {
        public static string ToStr(this Reaction obj)
        {
            switch (obj)
            {
                case Reaction.Like:
                    return "like";

                case Reaction.Love:
                    return "love";

                case Reaction.Laugh:
                    return "laugh";

                case Reaction.Hmm:
                    return "hmm";

                case Reaction.Surprise:
                    return "surprise";

                case Reaction.Congrats:
                    return "congrats";

                case Reaction.Angry:
                    return "angry";

                case Reaction.Confused:
                    return "confused";

                case Reaction.Rip:
                    return "rip";

                case Reaction.Pudding:
                    return "pudding";

                default:
                    throw new ArgumentOutOfRangeException(nameof(obj), obj, null);
            }
        }
    }
}