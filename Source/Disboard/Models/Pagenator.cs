using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;

namespace Disboard.Models
{
    internal interface IPagenator
    {
        /// <summary>
        ///     Valid client
        /// </summary>
        AppClient Client { get; set; }

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
    }

    /// <summary>
    ///     RFC 5988 Web Linking Object
    /// </summary>
    public class Pagenator<T> : List<T>, IPagenator
    {
        // aliases
        private AppClient Client => ((IPagenator) this).Client;
        private string First => ((IPagenator) this).First;
        private string Next => ((IPagenator) this).Next;
        private string Prev => ((IPagenator) this).Prev;
        private string Last => ((IPagenator) this).Last;

        // implements
        AppClient IPagenator.Client { get; set; }
        string IPagenator.First { get; set; }
        string IPagenator.Next { get; set; }
        string IPagenator.Prev { get; set; }
        string IPagenator.Last { get; set; }

        /// <summary>
        ///     Query first page
        /// </summary>
        public async Task<Pagenator<T>> FirstAsync()
        {
            if (string.IsNullOrWhiteSpace(First))
                throw new InvalidOperationException();
            return await Client.GetAsync<Pagenator<T>>(AsEndpoint(First)).Stay();
        }

        /// <summary>
        ///     Query next page
        /// </summary>
        public async Task<Pagenator<T>> NextAsync()
        {
            if (string.IsNullOrWhiteSpace(Next))
                throw new InvalidOperationException();
            return await Client.GetAsync<Pagenator<T>>(AsEndpoint(Next)).Stay();
        }

        /// <summary>
        ///     Query previous page
        /// </summary>
        public async Task<Pagenator<T>> PrevAsync()
        {
            if (string.IsNullOrWhiteSpace(Prev))
                throw new InvalidOperationException();
            return await Client.GetAsync<Pagenator<T>>(AsEndpoint(Prev)).Stay();
        }

        /// <summary>
        ///     Query last page
        /// </summary>
        public async Task<Pagenator<T>> LastAsync()
        {
            if (string.IsNullOrWhiteSpace(Last))
                throw new InvalidOperationException();
            return await Client.GetAsync<Pagenator<T>>(AsEndpoint(Last)).Stay();
        }

        // https://example.com/api/v1/... を /api/v1/... にするあれ
        private static string AsEndpoint(string str)
        {
            return new Uri(str).AbsolutePath;
        }
    }
}