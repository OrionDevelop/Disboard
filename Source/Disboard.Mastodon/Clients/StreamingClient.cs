using System;
using System.Collections.Generic;

using Disboard.Clients;
using Disboard.Mastodon.Clients.Streaming;
using Disboard.Models;

namespace Disboard.Mastodon.Clients
{
    public class StreamingClient : ApiClient<MastodonClient>
    {
        protected internal StreamingClient(MastodonClient client) : base(client, "") { }

        public IObservable<IStreamMessage> HealthAsObservable(string host = null)
        {
            var url = ToUrl(host, "/api/v1/streaming/health");
            var connection = new StreamingConnection(Client, url);
            return connection.Connect();
        }

        public IObservable<IStreamMessage> UserAsObservable(string host = null)
        {
            var url = ToUrl(host, "/api/v1/streaming/user");
            var connection = new StreamingConnection(Client, url);
            return connection.Connect();
        }

        public IObservable<IStreamMessage> NotificationAsObservable(string host = null)
        {
            var url = ToUrl(host, "/api/v1/streaming/user/notification");
            var connection = new StreamingConnection(Client, url);
            return connection.Connect();
        }

        public IObservable<IStreamMessage> PublicAsObservable(bool isOnlyMedia, string host = null)
        {
            var url = ToUrl(host, "/api/v1/streaming/public");
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("only_media", isOnlyMedia.ToString().ToLower())};
            var connection = new StreamingConnection(Client, url, parameters);
            return connection.Connect();
        }

        public IObservable<IStreamMessage> LocalPublicAsObservable(bool isOnlyMedia, string host = null)
        {
            var url = ToUrl(host, "/api/v1/streaming/public/local");
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("only_media", isOnlyMedia.ToString().ToLower())};
            var connection = new StreamingConnection(Client, url, parameters);
            return connection.Connect();
        }

        public IObservable<IStreamMessage> DirectAsObservable(string host = null)
        {
            var url = ToUrl(host, "/api/v1/streaming/direct");
            var connection = new StreamingConnection(Client, url);
            return connection.Connect();
        }

        public IObservable<IStreamMessage> HashtagAsObservable(string tag, string host = null)
        {
            var url = ToUrl(host, "/api/v1/streaming/hashtag");
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("tag", AppClient.UrlEncode(tag))};
            var connection = new StreamingConnection(Client, url, parameters);
            return connection.Connect();
        }

        public IObservable<IStreamMessage> LocalHashtagAsObservable(string tag, string host = null)
        {
            var url = ToUrl(host, "/api/v1/streaming/hashtag/local");
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("tag", AppClient.UrlEncode(tag))};
            var connection = new StreamingConnection(Client, url, parameters);
            return connection.Connect();
        }

        public IObservable<IStreamMessage> ListAsObservable(long id, string host = null)
        {
            var url = ToUrl(host, "/api/v1/streaming/list");
            var parameters = new List<KeyValuePair<string, object>> {new KeyValuePair<string, object>("list", id)};
            var connection = new StreamingConnection(Client, url, parameters);
            return connection.Connect();
        }

        private string ToUrl(string host, string endpoint)
        {
            host = string.IsNullOrWhiteSpace(host) ? Client.Domain : host;
            return $"https://{host}{endpoint}";
        }
    }
}