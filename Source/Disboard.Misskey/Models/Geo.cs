using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class Geo : ApiResponse
    {
        [JsonProperty("altitude")]
        public double Altitude { get; set; }

        [JsonProperty("altitudeAccuracy")]
        public double AltitudeAccuracy { get; set; }

        [JsonProperty("accuracy")]
        public double Accuracy { get; set; }

        [JsonProperty("coordinates")]
        public double[] Coordinates { get; set; }

        [JsonProperty("heading")]
        public double Heading { get; set; }

        [JsonProperty("speed")]
        public double Speed { get; set; }
    }
}