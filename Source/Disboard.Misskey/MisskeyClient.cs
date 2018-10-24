using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

using Disboard.Misskey.Clients;
using Disboard.Misskey.Handlers;
using Disboard.Models;

using MisskeyAppClient = Disboard.Misskey.Clients.AppClient;

namespace Disboard.Misskey
{
    public class MisskeyClient : AppClient
    {
        public AggregationClient Aggregation { get; }
        public MisskeyAppClient App { get; }
        public AuthClient Auth { get; }

        public MisskeyClient(string domain, HttpClientHandler innerHandler = null) : base(domain, new MisskeyAuthenticationHandler(innerHandler), RequestMode.Json)
        {
            BinaryParameters = new List<string> {"file"};

            Aggregation = new AggregationClient(this);
            App = new MisskeyAppClient(this);
            Auth = new AuthClient(this);
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