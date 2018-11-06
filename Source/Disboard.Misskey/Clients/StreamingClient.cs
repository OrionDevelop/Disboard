using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;

using Disboard.Clients;
using Disboard.Misskey.Clients.Streaming;
using Disboard.Misskey.Models.Streaming;
using Disboard.Models;

namespace Disboard.Misskey.Clients
{
    public class StreamingClient : ApiClient<MisskeyClient>
    {
        private StreamingConnection _connection;
        private IDisposable _disposable;
        private IConnectableObservable<IStreamMessage> _observable;

        protected internal StreamingClient(MisskeyClient client) : base(client, "") { }

        public async Task ConnectAsync(string host = null)
        {
            var url = $"wss://{(string.IsNullOrWhiteSpace(host) ? Client.Domain : host)}/streaming";
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("i", Client.EncryptedAccessToken)};
            _connection = new StreamingConnection(Client, url, parameters);
            _observable = _connection.Connect().Publish();
            _disposable = _observable.Connect(); // start
            await _connection.WaitForConnectionEstablished();
        }

        public void Disconnect()
        {
            _disposable?.Dispose(); // Goodbye
        }

        public IObservable<IStreamMessage> MainAsObservable()
        {
            var id = Guid.NewGuid().ToString();
            var body = new WsRequest {Body = new Connection {Channel = "main", Id = id}, Type = "connect"};
            SendAsync(body).Wait();
            return _observable.Cast<WsResponse>().Where(w => Passable(w, id)).Select(w => w.Body.Decoded);
        }

        public IObservable<IStreamMessage> HomeTimelineAsObservable()
        {
            var id = Guid.NewGuid().ToString();
            var body = new WsRequest {Body = new Connection {Channel = "homeTimeline", Id = id}, Type = "connect"};
            SendAsync(body).Wait();
            return _observable.Cast<WsResponse>().Where(w => Passable(w, id)).Select(w => w.Body.Decoded);
        }

        public IObservable<IStreamMessage> LocalTimelineAsObservable()
        {
            var id = Guid.NewGuid().ToString();
            var body = new WsRequest {Body = new Connection {Channel = "localTimeline", Id = id}, Type = "connect"};
            SendAsync(body).Wait();
            return _observable.Cast<WsResponse>().Where(w => Passable(w, id)).Select(w => w.Body.Decoded);
        }

        public IObservable<IStreamMessage> GlobalTimelineAsObservable()
        {
            var id = Guid.NewGuid().ToString();
            var body = new WsRequest {Body = new Connection {Channel = "globalTimeline", Id = id}, Type = "connect"};
            SendAsync(body).Wait();
            return _observable.Cast<WsResponse>().Where(w => Passable(w, id)).Select(w => w.Body.Decoded);
        }

        internal async Task SendAsync(WsRequest request)
        {
            if (_connection == null)
                throw new InvalidOperationException("Does not connect to WebSocket stream");
            await _connection.SendAsync(request);
        }

        internal async Task<T> SendAsync<T>(WsRequest request)
        {
            if (_connection == null)
                throw new InvalidOperationException("Does not connect to WebSocket stream");
            await _connection.SendAsync(request);
            var response = await _observable.Cast<WsResponse>().FirstAsync(w => $"api:{request.Body.Id}" == w?.Type);
            if (response.Body is WsRestResponseObject obj)
                return obj.Res.ToObject<T>();
            return default;
        }

        private bool Passable(WsResponse response, string id)
        {
            return response.Type == "channel" && response.Body?.Id == id;
        }
    }
}