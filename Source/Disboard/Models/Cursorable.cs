using System;
using System.Threading.Tasks;

using Disboard.Extensions;

using Newtonsoft.Json;

namespace Disboard.Models
{
    /// <summary>
    ///     Cursorable object with `next_url` property.
    /// </summary>
    public class Cursorable<T> : ApiResponse
    {
        /// <summary>
        ///     Next url
        /// </summary>
        [JsonProperty("next_url")]
        public string NextUrl { get; set; }

        internal AppClient Client { get; set; }

        /// <summary>
        ///     Query next page
        /// </summary>
        /// <returns></returns>
        public async Task<T> NextAsync()
        {
            if (string.IsNullOrWhiteSpace(NextUrl))
                throw new InvalidOperationException();
            return await Client.GetAsync<T>(NextUrl).Stay();
        }
    }
}