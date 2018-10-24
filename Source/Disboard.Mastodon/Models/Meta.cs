using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Mastodon.Models
{
    public class Meta : ApiResponse
    {
        /// <summary>
        ///     If meta type is "video", this property is filled.
        /// </summary>
        [JsonProperty("length")]
        public string Length { get; set; }

        /// <summary>
        ///     If meta type is "video", this property is filled.
        /// </summary>
        [JsonProperty("duration")]
        public double? Duration { get; set; }

        /// <summary>
        ///     If meta type is "video", this property is filled.
        /// </summary>
        [JsonProperty("audio_encode")]
        public string AudioEncode { get; set; }

        /// <summary>
        ///     If meta type is "video", this property is filled.
        /// </summary>
        [JsonProperty("audio_channels")]
        public string AudioChannels { get; set; }

        /// <summary>
        ///     If meta type is "video", this property is filled.
        /// </summary>
        [JsonProperty("audio_bitrate")]
        public string AudioBitrate { get; set; }

        /// <summary>
        ///     If meta type is "video", this property is filled.
        /// </summary>
        [JsonProperty("fps")]
        public int? Fps { get; set; }

        /// <summary>
        ///     If meta type is "video", this property is filled.
        /// </summary>
        [JsonProperty("size")]
        public string Size { get; set; }

        /// <summary>
        ///     If meta type is "video", this property is filled.
        /// </summary>
        [JsonProperty("width")]
        public int? Width { get; set; }

        /// <summary>
        ///     If meta type is "video", this property is filled.
        /// </summary>
        [JsonProperty("height")]
        public int? Height { get; set; }

        /// <summary>
        ///     If meta type is "video", this property is filled.
        /// </summary>
        [JsonProperty("aspect")]
        public double? Aspect { get; set; }

        /// <summary>
        ///     If meta type is "video", this property is filled.
        /// </summary>
        [JsonProperty("rotate")]
        public double? Rotate { get; set; }

        [JsonProperty("focus")]
        public Focus Focus { get; set; }

        [JsonProperty("original")]
        public Metadata Original { get; set; }

        [JsonProperty("small")]
        public Metadata Small { get; set; }
    }
}