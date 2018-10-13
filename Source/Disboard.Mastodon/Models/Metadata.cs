using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    public class Metadata : ApiResponse
    {
        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        ///     If meta type is "image", this property is filled.
        /// </summary>
        [JsonProperty("size")]
        public string Size { get; set; }

        /// <summary>
        ///     If meta type is "image", this property is filled.
        /// </summary>
        [JsonProperty("aspect")]
        public double? Aspect { get; set; }

        /// <summary>
        ///     If meta type is "video", this property is filled.
        /// </summary>
        [JsonProperty("frame_rate")]
        public string FrameRate { get; set; }

        /// <summary>
        ///     If meta type is "video", this property is filled.
        /// </summary>
        [JsonProperty("duration")]
        public double? Duration { get; set; }

        /// <summary>
        ///     If meta type is "video", this property is filled.
        /// </summary>
        [JsonProperty("bitrate")]
        public double? Bitrate { get; set; }
    }
}