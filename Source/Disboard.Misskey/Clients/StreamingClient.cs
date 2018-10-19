using System;
using System.Collections.Generic;
using System.Reactive.Linq;

using Disboard.Clients;
using Disboard.Misskey.Clients.Streaming;
using Disboard.Misskey.Models.Streaming;
using Disboard.Models;

namespace Disboard.Misskey.Clients
{
    public class StreamingClient : ApiClient<MisskeyClient>
    {
        protected internal StreamingClient(MisskeyClient client) : base(client, "") { }

        public IObservable<IStreamMessage> MainAsObservable(string host = null)
        {
            var id = Guid.NewGuid().ToString();
            var body = new WsRequest {Body = new Connection {Channel = "main", Id = id}, Type = "connect"};
            var (connection, observable) = ConnectToStreaming(host);
            connection.SendAsync(body).Wait();

            return observable.Cast<WsResponse>().Where(w => Passable(w, id)).Select(w => w.Body.Decoded);
        }

        public IObservable<IStreamMessage> HomeTimelineAsObservable(string host = null)
        {
            var id = Guid.NewGuid().ToString();
            var body = new WsRequest {Body = new Connection {Channel = "homeTimeline", Id = id}, Type = "connect"};
            var (connection, observable) = ConnectToStreaming(host);
            connection.SendAsync(body).Wait();

            return observable.Cast<WsResponse>().Where(w => Passable(w, id)).Select(w => w.Body.Decoded);
        }

        public IObservable<IStreamMessage> LocalTimelineAsObservable(string host = null)
        {
            var id = Guid.NewGuid().ToString();
            var body = new WsRequest {Body = new Connection {Channel = "localTimeline", Id = id}, Type = "connect"};
            var (connection, observable) = ConnectToStreaming(host);
            connection.SendAsync(body).Wait();

            return observable.Cast<WsResponse>().Where(w => Passable(w, id)).Select(w => w.Body.Decoded);
        }

        public IObservable<IStreamMessage> GlobalTimelineAsObservable(string host = null)
        {
            var id = Guid.NewGuid().ToString();
            var body = new WsRequest {Body = new Connection {Channel = "globalTimeline", Id = id}, Type = "connect"};
            var (connection, observable) = ConnectToStreaming(host);
            connection.SendAsync(body).Wait();

            return observable.Cast<WsResponse>().Where(w => Passable(w, id)).Select(w => w.Body.Decoded);
        }

        private (StreamingConnection, IObservable<IStreamMessage>) ConnectToStreaming(string host = null)
        {
            var url = $"wss://{(string.IsNullOrWhiteSpace(host) ? Client.Domain : host)}/streaming";
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("i", Client.EncryptedAccessToken)};
            var connection = new StreamingConnection(Client, url, parameters);
            var observable = connection.Connect().Publish();
            observable.Connect(); // 接続時に Send する必要があるので、購読を開始する必要がある
            connection.WaitForConnectionEstablished().Wait();

            return (connection, observable);
        }

        private bool Passable(WsResponse response, string id)
        {
            return response.Type == "channel" && response.Body?.Id == id;
        }
    }
}