using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class FolderExtend : Folder
    {
        [JsonProperty("foldersCount")]
        public int FoldersCount { get; set; }

        [JsonProperty("filesCount")]
        public int FilesCount { get; set; }

        [JsonProperty("parent")]
        public FolderExtend Parent { get; set; }
    }
}