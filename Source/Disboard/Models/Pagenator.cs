using System;
using System.Threading.Tasks;

using Disboard.Extensions;

namespace Disboard.Models
{
    /// <summary>
    ///     RFC 5988 Web Linking Object
    /// </summary>
    public class Pagenator<T> : ApiResponse
    {
        internal ClientBase Client { get; set; }

        /// <summary>
        ///     First page
        /// </summary>
        public string First { get; set; }

        /// <summary>
        ///     Next page
        /// </summary>
        public string Next { get; set; }

        /// <summary>
        ///     Previous page
        /// </summary>
        public string Prev { get; set; }

        /// <summary>
        ///     Last page
        /// </summary>
        public string Last { get; set; }

        /// <summary>
        ///     Query first page
        /// </summary>
        public async Task<T> FirstAsync()
        {
            if (string.IsNullOrWhiteSpace(First))
                throw new InvalidOperationException();
            return await Client.GetAsync<T>(First).Stay();
        }

        /// <summary>
        ///     Query next page
        /// </summary>
        public async Task<T> NextAsync()
        {
            if (string.IsNullOrWhiteSpace(Next))
                throw new InvalidOperationException();
            return await Client.GetAsync<T>(Next).Stay();
        }

        /// <summary>
        ///     Query previous page
        /// </summary>
        public async Task<T> PrevAsync()
        {
            if (string.IsNullOrWhiteSpace(Prev))
                throw new InvalidOperationException();
            return await Client.GetAsync<T>(Prev).Stay();
        }

        /// <summary>
        ///     Query last page
        /// </summary>
        public async Task<T> LastAsync()
        {
            if (string.IsNullOrWhiteSpace(Last))
                throw new InvalidOperationException();
            return await Client.GetAsync<T>(Last).Stay();
        }
    }
}