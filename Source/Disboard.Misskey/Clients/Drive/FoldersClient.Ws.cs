using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients.Drive
{
    public partial class FoldersClient
    {
        public async Task<Folder> CreateWsAsync(string name = null, string parentId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("name", name);
            parameters.AddIfValidValue("parentId", parentId);

            return await SendWsAsync<Folder>("/create", parameters).Stay();
        }

        public async Task DeleteWsAsync(string folderId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("folderId", folderId)};

            await SendWsAsync("/delete", parameters).Stay();
        }

        public async Task<List<Folder>> FindWsAsync(string name, string parentId = null)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("name", name)};
            parameters.AddIfValidValue("parentId", parentId);

            return await SendWsAsync<List<Folder>>("/find", parameters).Stay();
        }

        public async Task<FolderExtend> ShowWsAsync(string folderId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("folderId", folderId)};

            return await SendWsAsync<FolderExtend>("/show", parameters).Stay();
        }

        public async Task<Folder> UpdateWsAsync(string folderId, string name = null, string parentId = null)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("folderId", folderId)};
            parameters.AddIfValidValue("name", name);
            parameters.AddIfValidValue("parentId", parentId);

            return await SendWsAsync<Folder>("/update", parameters).Stay();
        }
    }
}