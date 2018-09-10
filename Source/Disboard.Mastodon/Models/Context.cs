﻿using System.Collections.Generic;

using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    public class Context : ApiResponse
    {
        [JsonProperty("ancestors")]
        public List<Status> Ancestors { get; set; }

        [JsonProperty("descendants")]
        public List<Status> Descendants { get; set; }
    }
}