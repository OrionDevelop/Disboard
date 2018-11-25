using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Misskey.Clients;
using Disboard.Misskey.Handlers;
using Disboard.Misskey.Models.Streaming;
using Disboard.Models;

using MisskeyAppClient = Disboard.Misskey.Clients.AppClient;

namespace Disboard.Misskey
{
    public partial class MisskeyClient : AppClient
    {
        public AggregationClient Aggregation { get; }
        public MisskeyAppClient App { get; }
        public AuthClient Auth { get; }
        public BlockingClient Blocking { get; }
        public ChartsClient Charts { get; }
        public DriveClient Drive { get; }
        public FollowingClient Following { get; }
        public HashtagsClient Hashtags { get; }
        public IClient I { get; }
        public MessagingClient Messaging { get; }
        public MuteClient Mute { get; }
        public MyClient My { get; }
        public NotesClient Notes { get; }
        public NotificationsClient Notifications { get; }
        public StreamingClient Streaming { get; }
        public UsernameClient Username { get; }
        public UsersClient Users { get; }

        public MisskeyClient(string domain, HttpClientHandler innerHandler = null) : this(new Credential {Domain = domain}, innerHandler) { }

        public MisskeyClient(Credential credential, HttpClientHandler innerHandler = null) : base(credential, new MisskeyAuthenticationHandler(innerHandler), RequestMode.Json)
        {
            BinaryParameters = new List<string> {"file"};

            Aggregation = new AggregationClient(this);
            App = new MisskeyAppClient(this);
            Auth = new AuthClient(this);
            Blocking = new BlockingClient(this);
            Charts = new ChartsClient(this);
            Drive = new DriveClient(this);
            Following = new FollowingClient(this);
            Hashtags = new HashtagsClient(this);
            I = new IClient(this);
            Messaging = new MessagingClient(this);
            Mute = new MuteClient(this);
            My = new MyClient(this);
            Notes = new NotesClient(this);
            Notifications = new NotificationsClient(this);
            Streaming = new StreamingClient(this);
            Username = new UsernameClient(this);
            Users = new UsersClient(this);
        }

        #region WsWrapper for Misskey endpoints

        public async Task<T> SendWsAsync<T>(string endpoint, List<KeyValuePair<string, object>> parameters = null)
        {
            return await Streaming.SendAsync<T>(WsRestRequestObject.CreateRestRequest(endpoint, parameters)).Stay();
        }

        public async Task SendWsAsync(string endpoint, List<KeyValuePair<string, object>> parameters = null)
        {
            await Streaming.SendAsync(WsRestRequestObject.CreateRestRequest(endpoint, parameters)).Stay();
        }

        #endregion

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

                return _encryptedAccessToken = string.Concat(sha256.ComputeHash(bytes).Select(w => $"{w:x2}"));
            }
        }

        #endregion
    }
}