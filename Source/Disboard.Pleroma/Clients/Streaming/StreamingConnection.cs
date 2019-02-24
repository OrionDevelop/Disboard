using System;
using System.Collections.Generic;
using System.Reactive.Linq;

using Disboard.Clients;
using Disboard.Mastodon.Models.Streaming;
using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Pleroma.Clients.Streaming
{
    internal class StreamingConnection : WebSocketStreamingConnection<Pleroma.PleromaClient>
    {
        private readonly string _endpoint;
        private readonly IEnumerable<KeyValuePair<string, object>> _parameters;

        public StreamingConnection(Pleroma.PleromaClient client, string endpoint, IEnumerable<KeyValuePair<string, object>> parameters) : base(client)
        {
            _endpoint = endpoint;
            _parameters = parameters;
        }

        public IObservable<IStreamMessage> Connect()
        {
            return Connect(_endpoint, _parameters).Where(w => w.GetType() != typeof(ConnectMessage));
        }

        protected override bool IsMatchRequestAndResponse(object request, IStreamMessage response)
        {
            return true;
        }

        protected override IStreamMessage ParseData(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return null;

            var data = JsonConvert.DeserializeObject<WebSocketFrame>(message);
            switch (data.Event)
            {
                case "update":
                    return JsonConvert.DeserializeObject<StatusMessage>(data.Payload);

                case "notification":
                    return JsonConvert.DeserializeObject<NotificationMessage>(data.Payload);

                case "delete":
                    return new DeleteMessage {Id = long.Parse(data.Payload)};

                case "filters_changed":
                    return new FilterChangedMessage();

                default:
                    throw new ArgumentOutOfRangeException(data.Event);
            }
        }
    }
}