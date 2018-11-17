using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Clients.Drive;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients
{
    public partial class DriveClient : MisskeyApiClient
    {
        public FilesClient Files { get; }
        public FoldersClient Folders { get; }

        protected internal DriveClient(MisskeyClient client) : base(client, "drive")
        {
            Files = new FilesClient(client);
            Folders = new FoldersClient(client);
        }

        public async Task<List<File>> FilesAsync(string folderId = null, string type = null, int? limit = null, string sinceId = null, string untilId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("folderId", folderId);
            parameters.AddIfValidValue("type", type);
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("sinceId", sinceId);
            parameters.AddIfValidValue("untilId", untilId);

            return await PostAsync<List<File>>("/files", parameters).Stay();
        }

        public async Task<List<Folder>> FoldersAsync(string folderId = null, int? limit = null, string sinceId = null, string untilId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("folderId", folderId);
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("sinceId", sinceId);
            parameters.AddIfValidValue("untilId", untilId);

            return await PostAsync<List<Folder>>("/folders", parameters).Stay();
        }

        public async Task<List<File>> StreamAsync(string type = null, int? limit = null, string sinceId = null, string untilId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("type", type);
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("sinceId", sinceId);
            parameters.AddIfValidValue("untilId", untilId);

            return await PostAsync<List<File>>("/stream", parameters).Stay();
        }
    }
}