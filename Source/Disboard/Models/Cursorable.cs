using System;
using System.Threading.Tasks;

using Disboard.Extensions;

using Newtonsoft.Json;

namespace Disboard.Models
{
    /// <summary>
    ///     Cursorable object with `next_url` property.
    /// </summary>
    public interface ICursorable<T>
    {
        /// <summary>
        ///     Next url
        /// </summary>
        string NextUrl { get; set; }

        /// <summary>
        ///     Instance of <see cref="ClientBase" />
        /// </summary>
        ClientBase Client { set; }

        /// <summary>
        ///     Query next page
        /// </summary>
        /// <returns></returns>
        Task<T> NextAsync();
    }

    /// <summary>
    ///     ICursorable implementation
    /// </summary>
    public class Cursorable<T> : ICursorable<T>
    {
        /// <inheritdoc />
        [JsonProperty("next_url")]
        public string NextUrl { get; set; }

        /// <inheritdoc />
        public ClientBase Client { get; set; }

        /// <inheritdoc />
        public async Task<T> NextAsync()
        {
            if (string.IsNullOrWhiteSpace(NextUrl))
                throw new InvalidOperationException();
            return await Client.GetAsync<T>(NextUrl, null).Stay();
        }
    }
}