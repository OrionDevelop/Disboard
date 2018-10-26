using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Misskey.Clients.Aggregation;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients
{
    public class AggregationClient : ApiClient<MisskeyClient>
    {
        public UsersClient Users { get; }

        protected internal AggregationClient(MisskeyClient client) : base(client, "/api/aggregation")
        {
            Users = new UsersClient(client);
        }

        public async Task<List<Hashtag>> HashtagsAsync()
        {
            return await PostAsync<List<Hashtag>>("/hashtags").Stay();
        }
    }
}