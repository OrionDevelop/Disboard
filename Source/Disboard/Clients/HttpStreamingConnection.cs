using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive.Linq;

using Disboard.Extensions;
using Disboard.Models;

namespace Disboard.Clients
{
    /// <summary>
    ///     <para> Server Sent Events (SSE) Client implementation for Disboard.</para>
    ///     <para>
    ///         For more information, please see this article:
    ///         https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events
    ///     </para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class HttpStreamingConnection<T> where T : AppClient
    {
        protected T ApiClient { get; }

        protected HttpStreamingConnection(T client)
        {
            ApiClient = client;
        }

        protected IObservable<IStreamMessage> Connect(string endpoint, IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            return Observable.Create<IStreamMessage>(async (observer, token) =>
            {
                try
                {
                    var stream = await ApiClient.GetStreamAsync(endpoint, parameters).Stay();
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

        protected abstract IStreamMessage ParseEvent(string @event, string payload);

        protected abstract IStreamMessage ParseData(string payload);
    }
}