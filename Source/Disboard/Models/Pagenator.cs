using System;
using System.Threading.Tasks;

using Disboard.Extensions;

namespace Disboard.Models
{
    /// <summary>
    ///     RFC 5988 Web Linking Object
    /// </summary>
    public interface IPagenator<T>
    {
        /// <summary>
        ///     First page
        /// </summary>
        string First { get; set; }

        /// <summary>
        ///     Next page
        /// </summary>
        string Next { get; set; }

        /// <summary>
        ///     Previous page
        /// </summary>
        string Prev { get; set; }

        /// <summary>
        ///     Last page
        /// </summary>
        string Last { get; set; }

        /// <summary>
        ///     Instance of <see cref="ClientBase" />
        /// </summary>
        ClientBase Client { set; }

        /// <summary>
        ///     Query first page
        /// </summary>
        Task<T> FirstAsync();

        /// <summary>
        ///     Query next page
        /// </summary>
        Task<T> NextAsync();

        /// <summary>
        ///     Query previous page
        /// </summary>
        Task<T> PrevAsync();

        /// <summary>
        ///     Query last page
        /// </summary>
        Task<T> LastAsync();
    }

    /// <summary>
    ///     IPagenator implementation
    /// </summary>
    public class Pagenator<T> : IPagenator<T>
    {
        /// <inheritdoc />
        public string First { get; set; }

        /// <inheritdoc />
        public string Next { get; set; }

        /// <inheritdoc />
        public string Prev { get; set; }

        /// <inheritdoc />
        public string Last { get; set; }

        /// <inheritdoc />
        public ClientBase Client { get; set; }

        /// <inheritdoc />
        public async Task<T> FirstAsync()
        {
            if (string.IsNullOrWhiteSpace(First))
                throw new InvalidOperationException();
            return await Client.GetAsync<T>(First, null).Stay();
        }

        /// <inheritdoc />
        public async Task<T> NextAsync()
        {
            if (string.IsNullOrWhiteSpace(Next))
                throw new InvalidOperationException();
            return await Client.GetAsync<T>(Next, null).Stay();
        }

        /// <inheritdoc />
        public async Task<T> PrevAsync()
        {
            if (string.IsNullOrWhiteSpace(Prev))
                throw new InvalidOperationException();
            return await Client.GetAsync<T>(Prev, null).Stay();
        }

        /// <inheritdoc />
        public async Task<T> LastAsync()
        {
            if (string.IsNullOrWhiteSpace(Last))
                throw new InvalidOperationException();
            return await Client.GetAsync<T>(Last, null).Stay();
        }
    }
}