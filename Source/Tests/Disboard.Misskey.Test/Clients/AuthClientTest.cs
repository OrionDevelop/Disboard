using System.Threading.Tasks;

using Xunit;

namespace Disboard.Misskey.Test.Clients
{
    public class AuthClientTest : MisskeyTestClient
    {
        [Fact(Skip = "This method does not worked")]
        public async Task AcceptAsync()
        {
            await TestClient.Auth.AcceptAsync("");
        }
    }
}