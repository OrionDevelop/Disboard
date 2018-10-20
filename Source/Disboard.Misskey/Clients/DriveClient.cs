﻿using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Misskey.Clients.Drive;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients
{
    public class DriveClient : ApiClient<MisskeyClient>
    {
        public FilesClient Files { get; }
        public FoldersClient Folders { get; }

        protected internal DriveClient(MisskeyClient client) : base(client, "/api/drive")
        {
            Files = new FilesClient(client);
            Folders = new FoldersClient(client);
        }

        public async Task<IEnumerable<File>> FilesAsync(string folderId = null, string type = null, int? limit = null, int? sinceId = null, int? untilId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("folderId", folderId);
            parameters.AddIfValidValue("type", type);
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("sinceId", sinceId);
            parameters.AddIfValidValue("untilId", untilId);

            return await PostAsync<IEnumerable<File>>("/files", parameters).Stay();
        }

        public async Task<IEnumerable<Folder>> FoldersAsync(string folderId = null, int? limit = null, int? sinceId = null, int? untilId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("folderId", folderId);
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("sinceId", sinceId);
            parameters.AddIfValidValue("untilId", untilId);

            return await PostAsync<IEnumerable<Folder>>("/folders", parameters).Stay();
        }

        public async Task<IEnumerable<File>> StreamAsync(string type = null, int? limit = null, int? sinceId = null, int? untilId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("type", type);
            parameters.AddIfValidValue("limit", limit);
            parameters.AddIfValidValue("sinceId", sinceId);
            parameters.AddIfValidValue("untilId", untilId);

            return await PostAsync<IEnumerable<File>>("/stream", parameters).Stay();
        }
    }
}