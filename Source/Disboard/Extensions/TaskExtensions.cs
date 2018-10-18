using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Disboard.Extensions
{
    public static class TaskExtensions
    {
        public static ConfiguredTaskAwaitable<T> Stay<T>(this Task<T> obj)
        {
            return obj.ConfigureAwait(false);
        }

        public static ConfiguredTaskAwaitable Stay(this Task obj)
        {
            return obj.ConfigureAwait(false);
        }
    }
}