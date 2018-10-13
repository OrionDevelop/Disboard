using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Mastodon.Enums;
using Disboard.Mastodon.Models;
using Disboard.Utils;

namespace Disboard.Mastodon.Clients
{
    public class FiltersClient : ApiClient<MastodonClient>
    {
        protected internal FiltersClient(MastodonClient client) : base(client, "/api/v1/filters") { }

        public async Task<List<Filter>> ListAsync()
        {
            return await GetAsync<List<Filter>>().Stay();
        }

        public async Task<Filter> CreateAsync(string phrase, FilterContext context, long? expiresIn = null, bool? isIrreversible = null, bool? isWholeWord = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("phrase", phrase)
            };
            parameters.AddRangeOfValues("context[]", context.Separate());
            parameters.AddIfValidValue("expires_in", expiresIn);
            parameters.AddIfValidValue("irreversible", isIrreversible);
            parameters.AddIfValidValue("whole_word", isWholeWord);

            return await PostAsync<Filter>(parameters: parameters).Stay();
        }

        public async Task<Filter> ShowAsync(long id)
        {
            return await GetAsync<Filter>($"/{id}").Stay();
        }

        public async Task<Filter> UpdateAsync(long id, string phrase = null, FilterContext? context = null, long? expiresIn = null, bool? isIrreversible = null, bool? isWholeWord = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("phrase", phrase);
            if (context.HasValue)
                parameters.AddRangeOfValues("context[]", context.Value.Separate());
            parameters.AddIfValidValue("expires_in", expiresIn);
            parameters.AddIfValidValue("irreversible", isIrreversible);
            parameters.AddIfValidValue("whole_word", isWholeWord);

            return await PutAsync<Filter>($"/{id}", parameters).Stay();
        }

        public async Task DestroyAsync(long id)
        {
            await DeleteAsync($"/{id}").Stay();
        }
    }
}