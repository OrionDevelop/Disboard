using System;
using System.Collections.Generic;

using Disboard.Clients;
using Disboard.Mastodon.Models.Streaming;
using Disboard.Models;

using Newtonsoft.Json;

namespace Disboard.Mastodon.Clients.Streaming
{
    internal class StreamingConnection : HttpStreamingConnection<MastodonClient>
    {
        private readonly string _endpoint;
        private readonly IEnumerable<KeyValuePair<string, object>> _parameters;

        public StreamingConnection(MastodonClient client, string endpoint, IEnumerable<KeyValuePair<string, object>> parameters = null) : base(client)
        {
            _endpoint = endpoint;
            _parameters = parameters;
        }

        public IObservable<IStreamMessage> Connect()
        {
            return Connect(_endpoint, _parameters);
        }

        protected override IStreamMessage ParseEvent(string @event, string payload)
        {
            var data = payload.Substring(payload.IndexOf(":", StringComparison.Ordinal) + ": ".Length);
            switch (@event.Substring(@event.IndexOf(":", StringComparison.Ordinal) + ": ".Length))
            {
                case "update":
                    return JsonConvert.DeserializeObject<StatusMessage>(data);

                case "notification":
                    return JsonConvert.DeserializeObject<NotificationMessage>(data);

                case "delete":
                    return new DeleteMessage {Id = long.Parse(data)};

                case "filters_changed":
                    return new FilterChangedMessage();

                default:
                    throw new ArgumentOutOfRangeException(@event);
            }
        }

        protected override IStreamMessage ParseData(string payload)
        {
            throw new NotSupportedException();
        }
    }
}