using System.Collections.Generic;
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

    }
}