using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Models;

// ReSharper disable PossibleMultipleEnumeration

namespace Disboard.Clients
{
    /// <summary>
    ///     <para>WebSocket Client implementation for Disboard.</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class WebSocketStreamingConnection<T>
    {
        private IObservable<IStreamMessage> _observable;

        protected T ApiClient { get; }
        protected ClientWebSocket WebSocketClient { get; private set; }

        protected WebSocketStreamingConnection(T client)
        {
            ApiClient = client;
        }

        protected IConnectableObservable<IStreamMessage> ConnectAsConnectable(string endpoint, IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            _observable = ConnectInternal(endpoint, parameters).Publish();
            return (IConnectableObservable<IStreamMessage>) _observable;
        }

        protected IObservable<IStreamMessage> Connect(string endpoint, IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            _observable = ConnectInternal(endpoint, parameters);
            return _observable;
        }

        protected IObservable<IStreamMessage> ConnectInternal(string endpoint, IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            return Observable.Create<IStreamMessage>(async (observer, token) =>
            {
                if (parameters != null && parameters.Any())
                    endpoint += $"?{string.Join("&", AppClient.AsUrlParameter(parameters))}";
                var uri = new Uri(endpoint);

                try
                {
                    WebSocketClient = new ClientWebSocket();
                    await WebSocketClient.ConnectAsync(uri, CancellationToken.None).Stay();

                    var buffer = new ArraySegment<byte>(new byte[1024]);
                    observer.OnNext(new ConnectMessage());

                    while ((WebSocketClient.State == WebSocketState.Open || WebSocketClient.State == WebSocketState.CloseReceived) && !token.IsCancellationRequested)
                    {
                        var result = await WebSocketClient.ReceiveAsync(buffer, token).Stay();
                        if (result.MessageType == WebSocketMessageType.Close)
                            break;

                        var bytes = AsSafeBytes(buffer, result);

                        // message greater than 1KB
                        if (!result.EndOfMessage)
                        {
                            var stream = new MemoryStream();
                            stream.Write(bytes, 0, bytes.Length);
                            do
                            {
                                result = await WebSocketClient.ReceiveAsync(buffer, token).Stay();
                                bytes = AsSafeBytes(buffer, result);
                                stream.Write(bytes, 0, bytes.Length);
                            } while (!result.EndOfMessage);

                            bytes = stream.ToArray();
                        }

                        if (result.MessageType == WebSocketMessageType.Text)
                            observer.OnNext(ParseData(Encoding.UTF8.GetString(bytes)));
                    }

                    observer.OnCompleted();
                }
                catch (Exception e)
                {
                    // だいたいこっち来そうではある...
                    observer.OnError(e);
                }
                return async () => await Disconnect().Stay();
            });
        }

        public async Task Disconnect()
        {
            if (WebSocketClient?.State == WebSocketState.Open)
                await WebSocketClient.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None).Stay();
        }

        // Hmm...
        public async Task WaitForConnectionEstablished()
        {
            if (WebSocketClient == null)
                throw new InvalidOperationException();

            // TODO: type-check
            await _observable.FirstAsync(w => w.GetType() == typeof(ConnectMessage)).ToTask().Stay();
        }

        protected async Task SendAsync(string message)
        {
            if (WebSocketClient == null || WebSocketClient.State != WebSocketState.Open)
                throw new InvalidOperationException();

            var bytes = new ArraySegment<byte>(Encoding.UTF8.GetBytes(message));
            await WebSocketClient.SendAsync(bytes, WebSocketMessageType.Text, true, new CancellationToken()).Stay();
        }

        protected async Task<TU> SendAsync<TU>(string message) where TU : IStreamMessage
        {
            await SendAsync(message).Stay();
            return await _observable.FirstAsync(w => IsMatchRequestAndResponse(message, w)).Cast<TU>().ToTask().Stay();
        }

        protected abstract bool IsMatchRequestAndResponse(object request, IStreamMessage response);

        protected abstract IStreamMessage ParseData(string message);

        private static byte[] AsSafeBytes(ArraySegment<byte> buffer, WebSocketReceiveResult wsrr)
        {
            return buffer.Take(wsrr.Count).ToArray();
        }
    }
}