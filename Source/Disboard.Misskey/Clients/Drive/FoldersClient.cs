using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Models;

namespace Disboard.Misskey.Clients.Drive
{
    public partial class FoldersClient : MisskeyApiClient
    {
        protected internal FoldersClient(MisskeyClient client) : base(client, "drive/folders") { }

        public async Task<Folder> CreateAsync(string name = null, string parentId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            parameters.AddIfValidValue("name", name);
            parameters.AddIfValidValue("parentId", parentId);

            return await PostAsync<Folder>("/create", parameters).Stay();
        }

        public async Task DeleteAsync(string folderId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("folderId", folderId)};

            await PostAsync("/delete", parameters).Stay();
        }

        public async Task<List<Folder>> FindAsync(string name, string parentId = null)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("name", name)};
            parameters.AddIfValidValue("parentId", parentId);

            return await PostAsync<List<Folder>>("/find", parameters).Stay();
        }

        public async Task<FolderExtend> ShowAsync(string folderId)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("folderId", folderId)};

            return await PostAsync<FolderExtend>("/show", parameters).Stay();
        }

        public async Task<Folder> UpdateAsync(string folderId, string name = null, string parentId = null)
        {
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("folderId", folderId)};
            parameters.AddIfValidValue("name", name);
            parameters.AddIfValidValue("parentId", parentId);

            return await PostAsync<Folder>("/update", parameters).Stay();
        }
    }
}