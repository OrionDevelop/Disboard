using System;
using System.Collections.Generic;

using Disboard.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Disboard.Misskey.Models
{
    public class File : ApiResponse
    {
        [JsonProperty("attachedNoteIds")]
        public IEnumerable<string> AttachedNoteIds { get; set; }

        [JsonProperty("createdAt")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("datasize")]
        public long Datasize { get; set; }

        [JsonProperty("folderId")]
        public string FolderId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("isSensitive")]
        public bool? IsSensitive { get; set; }

        [JsonProperty("md5")]
        public string Md5 { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("properties")]
        public MediaProperty Properties { get; set; }

        [JsonProperty("src")]
        public string Src { get; set; }

        [JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("webpublicUrl")]
        public string WebPublicUrl { get; set; }
    }
}