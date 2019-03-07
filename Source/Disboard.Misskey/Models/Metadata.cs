using System.Collections.Generic;

using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class Metadata : ApiResponse
    {
        [JsonProperty("maintainer")]
        public Maintainer Maintainer { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("clientVersion")]
        public string ClientVersion { get; set; }

        [JsonProperty("emojis")]
        public IEnumerable<ApiResponse> Emojis { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("secure")]
        public bool IsSecure { get; set; }

        [JsonProperty("machine")]
        public string Machine { get; set; }

        [JsonProperty("os")]
        public string Os { get; set; }

        [JsonProperty("node")]
        public string Node { get; set; }

        [JsonProperty("cpu")]
        public Cpu Cpu { get; set; }

        [JsonProperty("broadcasts")]
        public IEnumerable<Broadcast> Broadcasts { get; set; }

        [JsonProperty("disableRegistration")]
        public bool DisableRegistration { get; set; }

        [JsonProperty("disableLocalTimeline")]
        public bool DisableLocalTimeline { get; set; }

        [JsonProperty("driveCapacityPerLocalUserMb")]
        public long DriveCapacityPerLocalUserMb { get; set; }

        [JsonProperty("recaptchaSitekey")]
        public string RecaptchaSitekey { get; set; }

        [JsonProperty("swPublickey")]
        public string SwPublickey { get; set; }

        [JsonProperty("hidedTags")]
        public bool? HidedTags { get; set; }

        [JsonProperty("bannerUrl")]
        public string BannerUrl { get; set; }

        [JsonProperty("maxNoteTextLength")]
        public int MaxNoteTextLength { get; set; }

        [JsonProperty("features")]
        public Features Features { get; set; }
    }
}