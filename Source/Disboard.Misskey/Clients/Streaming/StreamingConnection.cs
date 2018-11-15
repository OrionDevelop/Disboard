// ReSharper disable PossibleMultipleEnumeration

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive.Subjects;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Extensions;
using Disboard.Misskey.Models;
using Disboard.Misskey.Models.Streaming;
using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Misskey.Clients.Streaming
{
    public class StreamingConnection : WebSocketStreamingConnection<MisskeyClient>
    {
        private readonly string _endpoint;
        private readonly IEnumerable<KeyValuePair<string, object>> _parameters;

        public StreamingConnection(MisskeyClient client, string endpoint, IEnumerable<KeyValuePair<string, object>> parameters) : base(client)
        {
            _endpoint = endpoint;
            _parameters = parameters;
        }

        public IConnectableObservable<IStreamMessage> Connect()
        {
            return ConnectAsConnectable(_endpoint, _parameters);
        }

        public async Task SendAsync(WsRequest request)
        {
            await SendAsync(JsonConvert.SerializeObject(request)).Stay();
        }

        protected override bool IsMatchRequestAndResponse(object request, IStreamMessage response)
        {
            return $"api:{(request as WsRequest)?.Body?.Id}" == (response as WsResponse)?.Body?.Id;
        }

        protected override IStreamMessage ParseData(string message)
        {
            var json = JsonConvert.DeserializeObject<WsResponse>(message);
            try
            {
                switch (json.Body?.Type)
                {
                    case "follow":
                        json.Body.Decoded = json.Body.RawBody.ToObject<FollowMessage>();
                        break;

                    case "followed":
                        json.Body.Decoded = json.Body.RawBody.ToObject<FollowedMessage>();
                        break;

                    case "mention":
                        json.Body.Decoded = json.Body.RawBody.ToObject<MentionMessage>();
                        break;

                    case "meUpdated":
                        json.Body.Decoded = json.Body.RawBody.ToObject<MeUpdatedMessage>();
                        break;

                    case "notification":
                        json.Body.Decoded = json.Body.RawBody.ToObject<NotificationMessage>();
                        break;

                    case "note":
                        json.Body.Decoded = json.Body.RawBody.ToObject<NoteMessage>();
                        break;

                    case "readAllNotifications":
                        json.Body.Decoded = new ReadAllNotificationsMessage();
                        break;

                    case "readAllUnreadMentions":
                        json.Body.Decoded = new ReadAllUnreadMentionsMessage();
                        break;

                    case "renote":
                        json.Body.Decoded = json.Body.RawBody.ToObject<RenoteMessage>();
                        break;

                    case "reply":
                        json.Body.Decoded = json.Body.RawBody.ToObject<ReplyMessage>();
                        break;

                    case "unfollow":
                        json.Body.Decoded = json.Body.RawBody.ToObject<UnfollowMessage>();
                        break;

                    default:
                        if (json.Body == null)
                            throw new ArgumentOutOfRangeException(json.Body?.Type);
                        if (json.Type.StartsWith("api"))
                            json.Body = new WsRestResponseObject {Res = json.Body.Extends["res"]}; // API call
                        else
                            json.Body.Decoded = new UnknownMessage {Body = json.Body.RawBody};
                        break;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return json;
        }
    }
}