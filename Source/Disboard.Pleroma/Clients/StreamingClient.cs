using System;
using System.Collections.Generic;

using Disboard.Clients;
using Disboard.Models;
using Disboard.Pleroma.Clients.Streaming;

namespace Disboard.Pleroma.Clients
{
    public class StreamingClient : ApiClient<Pleroma.PleromaClient>
    {
        protected internal StreamingClient(Pleroma.PleromaClient client) : base(client, "") { }

        public IObservable<IStreamMessage> UserAsObservable(string host = null)
        {
            var url = ToUrl(host, "/api/v1/streaming");
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("stream", "user"),
                new KeyValuePair<string, object>("access_token", Client.AccessToken)
            };
            var connection = new StreamingConnection(Client, url, parameters);
            return connection.Connect();
        }

        public IObservable<IStreamMessage> PublicAsObservable(string host = null)
        {
            var url = ToUrl(host, "/api/v1/streaming");
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("stream", "public"),
                new KeyValuePair<string, object>("access_token", Client.AccessToken)
            };
            var connection = new StreamingConnection(Client, url, parameters);
            return connection.Connect();
        }

        public IObservable<IStreamMessage> LocalPublicAsObservable(string host = null)
        {
            var url = ToUrl(host, "/api/v1/streaming");
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("stream", "public:local"),
                new KeyValuePair<string, object>("access_token", Client.AccessToken)
            };
            var connection = new StreamingConnection(Client, url, parameters);
            return connection.Connect();
        }

        public IObservable<IStreamMessage> DirectAsObservable(string host = null)
        {
            var url = ToUrl(host, "/api/v1/streaming");
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("stream", "direct"),
                new KeyValuePair<string, object>("access_token", Client.AccessToken)
            };
            var connection = new StreamingConnection(Client, url, parameters);
            return connection.Connect();
        }

        public IObservable<IStreamMessage> HashtagAsObservable(string tag, string host = null)
        {
            var url = ToUrl(host, "/api/v1/streaming");
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("stream", "hashtag"),
                new KeyValuePair<string, object>("tag", tag),
                new KeyValuePair<string, object>("access_token", Client.AccessToken)
            };
            var connection = new StreamingConnection(Client, url, parameters);
            return connection.Connect();
        }

        public IObservable<IStreamMessage> LocalHashtagAsObservable(string tag, string host = null)
        {
            var url = ToUrl(host, "/api/v1/streaming");
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("stream", "hashtag:local"),
                new KeyValuePair<string, object>("tag", tag),
                new KeyValuePair<string, object>("access_token", Client.AccessToken)
            };
            var connection = new StreamingConnection(Client, url, parameters);
            return connection.Connect();
        }

        public IObservable<IStreamMessage> ListAsObservable(long id, string host = null)
        {
            var url = ToUrl(host, "/api/v1/streaming");
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("stream", "list"),
                new KeyValuePair<string, object>("list", id),
                new KeyValuePair<string, object>("access_token", Client.AccessToken)
            };
            var connection = new StreamingConnection(Client, url, parameters);
            return connection.Connect();
        }

        private string ToUrl(string host, string endpoint)
        {
            host = string.IsNullOrWhiteSpace(host) ? Client.Domain : host;
            return $"wss://{host}{endpoint}";
        }
    }
}