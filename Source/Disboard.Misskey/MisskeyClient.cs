using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

using Disboard.Misskey.Clients;
using Disboard.Models;

using MisskeyAppClient = Disboard.Misskey.Clients.AppClient;

namespace Disboard.Misskey
{
    public class MisskeyClient : AppClient
    {
        internal string Domain { get; }

        public AggregationClient Aggregation { get; }
        public MisskeyAppClient App { get; }
        public AuthClient Auth { get; }

        public MisskeyClient(string domain, string secret = null) : base($"https://{domain}", AuthMode.Myself, RequestMode.Json)
        {
            Domain = domain;
            ClientSecret = secret;
            BinaryParameters = new List<string>();

            Aggregation = new AggregationClient(this);
            App = new MisskeyAppClient(this);
            Auth = new AuthClient(this);

            RegisterCustomAuthenticator(MisskeyAuthentication);
        }

        // Add "i" parameter to all request.
        private void MisskeyAuthentication(HttpClient client, string url, ref IEnumerable<KeyValuePair<string, object>> parameters)
        {
            if (string.IsNullOrWhiteSpace(AccessToken))
                return;
            if (parameters == null)
                parameters = new List<KeyValuePair<string, object>>();
            (parameters as List<KeyValuePair<string, object>>)?.Add(new KeyValuePair<string, object>("i", EncryptedAccessToken));
        }

        #region EncryptedAccessToken

        private string _encryptedAccessToken;

        public string EncryptedAccessToken
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_encryptedAccessToken))
                    return _encryptedAccessToken;

                var bytes = Encoding.UTF8.GetBytes(AccessToken + ClientSecret);
                var sha256 = new SHA256CryptoServiceProvider();

                return _encryptedAccessToken = string.Join("", sha256.ComputeHash(bytes).Select(w => $"{w:x2}"));
            }
        }

        #endregion
    }
}