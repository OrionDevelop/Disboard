using System;
using System.Collections.Generic;

using Disboard.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Disboard.Misskey.Models
{
    public class Media : ApiResponse
    {
        [JsonProperty("attachedNoteIds")]
        public List<string> AttachedNoteIds { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("createdAt")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("datasize")]
        public long DataSize { get; set; }

        [JsonProperty("folderId")]
        public string FolderId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("isSensitive")]
        public bool IsSensitive { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("md5")]
        public string Md5 { get; set; }

        [JsonProperty("properties")]
        public MediaProperty Properties { get; set; }

        [JsonProperty("src")]
        public string Src { get; set; }

        [JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}