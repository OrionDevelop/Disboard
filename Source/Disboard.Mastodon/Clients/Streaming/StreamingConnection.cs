using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive.Linq;

using Disboard.Extensions;
using Disboard.Mastodon.Models.Streaming;

using Newtonsoft.Json;

namespace Disboard.Mastodon.Clients.Streaming
{
    internal class StreamingConnection
    {
        private readonly MastodonClient _client;
        private readonly string _endpoint;
        private readonly IEnumerable<KeyValuePair<string, object>> _parameters;

        public StreamingConnection(MastodonClient client, string endpoint, IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            _client = client;
            _endpoint = endpoint;
            _parameters = parameters;
        }

        public IObservable<IStreamMessage> Connect()
        {
            return Observable.Create<IStreamMessage>(async (observer, token) =>
            {
                try
                {
                    var stream = await _client.GetStreamAsync(_endpoint, _parameters).Stay();
                    using (var sr = new StreamReader(stream))
                    {
                        while (!sr.EndOfStream)
                        {
                            if (token.IsCancellationRequested)
                                break;

                            var payload = sr.ReadLine();
                            if (string.IsNullOrWhiteSpace(payload) || payload.StartsWith(":"))
                                continue;

                            observer.OnNext(payload.StartsWith("event") ? ParseEvent(payload, sr.ReadLine()) : ParseData(payload));
                        }
                    }
                    observer.OnCompleted();
                }
                catch (Exception e)
                {
                    observer.OnError(e);
                }
            });
        }

        private IStreamMessage ParseEvent(string @event, string payload)
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

        private IStreamMessage ParseData(string payload)
        {
            throw new NotSupportedException();
        }
    }
}