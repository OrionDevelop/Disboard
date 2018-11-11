using Newtonsoft.Json;

namespace Disboard.Misskey.Models
{
    public class FileExtend : File
    {
        [JsonProperty("folder")]
        public FolderExtend Folder { get; set; }
    }
}