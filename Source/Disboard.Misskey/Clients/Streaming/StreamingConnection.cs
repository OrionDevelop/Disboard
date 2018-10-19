// ReSharper disable PossibleMultipleEnumeration

using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading.Tasks;

using Disboard.Clients;
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

        public IObservable<IStreamMessage> Connect()
        {
            return Connect(_endpoint, _parameters);
        }

        public async Task SendAsync(WsRequest request)
        {
            await SendAsync(JsonConvert.SerializeObject(request));
        }

        // Hmm...
        internal async Task WaitForConnectionEstablished()
        {
            await Task.Run(() =>
            {
                while (WebSocketClient == null || WebSocketClient.State != WebSocketState.Open) { }
            });
        }

        protected override bool IsMatchRequestAndResponse(object request, IStreamMessage response)
        {
            return $"api:{(request as WsRequest)?.Body?.Id}" == (response as WsResponse)?.Body?.Id;
        }

        protected override IStreamMessage ParseData(string message)
        {
            var json = JsonConvert.DeserializeObject<WsResponse>(message);
            switch (json?.Body?.Type)
            {
                case "note":
                    json.Body.Decoded = json.Body.Body.ToObject<NoteMessage>();
                    break;

                default:
                    throw new ArgumentOutOfRangeException(json.Body?.Type);
            }

            return json;
        }
    }
}