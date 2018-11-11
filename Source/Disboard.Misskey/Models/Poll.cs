using System.Collections.Generic;

using Disboard.Models;

namespace Disboard.Misskey.Models
{
    public class Poll : ApiResponse
    {
        public IEnumerable<Choice> Choices { get; set; }
    }
}