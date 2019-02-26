using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Models;

using Newtonsoft.Json.Linq;

namespace Disboard.Misskey.Clients.Drive
{
    public partial class FilesClient
    {
        public async Task<List<Note>> AttachedNotesWsAsync(string fileId)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("fileId", fileId) };

            return await SendWsAsync<List<Note>>("/attached-notes", parameters).Stay();
        }

        public async Task<File> CheckExistenceWsAsync(string md5)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("md5", md5) };

            var response = await SendWsAsync<JObject>("/check-existence", parameters).Stay();
            return response.ContainsKey("file") ? response["file"].ToObject<File>() : null;
        }

        public async Task<File> CreateWsAsync(string file, string folderId = null, bool? isSensitive = null, bool? force = null)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("file", file) };
            parameters.AddIfValidValue("folderId", folderId);
            parameters.AddIfValidValue("isSensitive", isSensitive); // Not work?
            parameters.AddIfValidValue("force", force);

            return await SendWsAsync<File>("/create", parameters).Stay();
        }

        public async Task DeleteWsAsync(string fileId)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("fileId", fileId) };

            await SendWsAsync("/delete", parameters).Stay();
        }

        public async Task<List<File>> FindWsAsync(string name, string folderId = null)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("name", name) };
            parameters.AddIfValidValue("folderId", folderId);

            return await SendWsAsync<List<File>>("/find", parameters).Stay();
        }

        public async Task<FileExtend> ShowWsAsync(string fileId = null, string url = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("fileId", fileId);
            parameters.AddIfValidValue("url", url);

            return await SendWsAsync<FileExtend>("/show", parameters).Stay();
        }

        public async Task<File> UpdateWsAsync(string fileId, string folderId = null, string name = null, bool? isSensitive = null)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("fileId", fileId) };
            parameters.AddIfValidValue("folderId", folderId);
            parameters.AddIfValidValue("name", name);
            parameters.AddIfValidValue("isSensitive", isSensitive);

            return await SendWsAsync<File>("/update", parameters).Stay();
        }

        public async Task<File> UploadFromUrlWsAsync(string url, string folderId = null, bool? isSensitive = null, bool? force = null)
        {
            var parameters = new List<KeyValuePair<string, object>> { new KeyValuePair<string, object>("url", url) };
            parameters.AddIfValidValue("folderId", folderId);
            parameters.AddIfValidValue("isSensitive", isSensitive); // Not work?
            parameters.AddIfValidValue("force", force);

            return await SendWsAsync<File>("/upload-from-url", parameters).Stay();
        }
    }
}