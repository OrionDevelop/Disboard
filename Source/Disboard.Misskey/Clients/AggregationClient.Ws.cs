using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients
{
    public partial class AggregationClient
    {
        public async Task<List<Hashtag>> HashtagsWsAsync()
        {
            return await SendWsAsync<List<Hashtag>>("/hashtags").Stay();
        }
    }
}