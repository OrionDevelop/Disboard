using System;

using Disboard.Converters;
using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    public class Activity : ApiResponse
    {
        [JsonProperty("week")]
        [JsonConverter(typeof(UnixTimeToDateTimeConverter))]
        public DateTime Week { get; set; }

        [JsonProperty("statuses")]
        public long Statuses { get; set; }

        [JsonProperty("logins")]
        public long Logins { get; set; }

        [JsonProperty("registrations")]
        public long Registrations { get; set; }
    }
}