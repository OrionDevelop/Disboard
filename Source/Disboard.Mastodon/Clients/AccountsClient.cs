using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Mastodon.Models;

namespace Disboard.Mastodon.Clients
{
    public class AccountsClient : ApiClient<MastodonClient>
    {
        internal AccountsClient(MastodonClient client) : base(client, "/api/v1/accounts") { }

        {
        public async Task<CredentialAccount> VerifyCredentials()
        {
            return await GetAsync<CredentialAccount>("/verify_credentials").Stay();
        }
    }
}