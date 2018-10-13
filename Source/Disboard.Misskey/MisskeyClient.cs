using System.Collections.Generic;

using Disboard.Misskey.Clients;
using Disboard.Models;

namespace Disboard.Misskey
{
    public class MisskeyClient : AppClient
    {
        internal string Domain { get; }

        public AuthClient Auth { get; }

        public MisskeyClient(string domain, string secret) : base($"https://{domain}", AuthMode.Myself, RequestMode.Json)
        {
            Domain = domain;
            ClientSecret = secret;
            BinaryParameters = new List<string>();

            Auth = new AuthClient(this);
        }
    }
}