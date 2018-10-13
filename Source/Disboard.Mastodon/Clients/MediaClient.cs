using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Mastodon.Models;

namespace Disboard.Mastodon.Clients
{
    public class MediaClient : ApiClient<MastodonClient>
    {
        protected internal MediaClient(MastodonClient client) : base(client, "/api/v1/media") { }

        public async Task<Attachment> CreateAsync(string file, string description = null, Point? focus = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("file", file) // marked as stream
            };
            parameters.AddIfValidValue("description", description);
            if (focus.HasValue)
                parameters.Add(new KeyValuePair<string, object>("focus", $"{focus.Value.X},{focus.Value.Y}"));

            return await PostAsync<Attachment>(parameters: parameters).Stay();
        }

        public async Task<Attachment> UpdateAsync(long id, string description = null, Point? focus = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("description", description);
            if (focus.HasValue)
                parameters.Add(new KeyValuePair<string, object>("focus", $"{focus.Value.X},{focus.Value.Y}"));

            return await PatchAsync<Attachment>($"/{id}", parameters).Stay();
        }
    }
}