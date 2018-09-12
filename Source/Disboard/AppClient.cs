using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Disboard.Extensions;
using Disboard.Models;
using Disboard.Utils;

using Newtonsoft.Json;

// ReSharper disable UnusedParameter.Local
// ReSharper disable PossibleMultipleEnumeration

namespace Disboard
{
    /// <summary>
    ///     Client Base Implementation
    /// </summary>
    public class AppClient
    {
        private readonly string _baseUrl;
        private readonly HttpClient _httpClient;
        private readonly string _version;
        public static string Version => "1.0";

        /// <summary>
        ///     Keys that send as binary data.
        /// </summary>
        protected List<string> BinaryParameters { get; set; } = new List<string>();

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="baseUrl">API base url</param>
        /// <param name="version">1.0a or 2.0</param>
        protected AppClient(string baseUrl, string version)
        {
            _baseUrl = baseUrl;
            _version = version;

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", $"Disboard/{Version}");
        }

        private void PrepareForAuthenticate(HttpMethod method, string url, IEnumerable<KeyValuePair<string, object>> parameters)
        {
            // ReSharper disable NotResolvedInText
            switch (_version)
            {
                case "1.0a":
                    PrepareForOAuth1A(method, url, parameters);
                    break;

                case "2.0":
                    PrepareForOAuth2();
                    break;

                default:
                    throw new ArgumentOutOfRangeException("version", _version, null);
            }

            // ReSharper restore NotResolvedInText
        }

        private void PrepareForOAuth1A(HttpMethod method, string url, IEnumerable<KeyValuePair<string, object>> parameters)
        {
            var dictionary = new SortedDictionary<string, string>
            {
                ["oauth_consumer_key"] = ConsumerKey,
                ["oauth_nonce"] = GenerateNonce(),
                ["oauth_signature_method"] = "HMAC-SHA1",
                ["oauth_timestamp"] = GenerateTimestamp(),
                ["oauth_version"] = "1.0"
            };
            if (!string.IsNullOrWhiteSpace(AccessToken))
                dictionary["oauth_token"] = AccessToken;

            if (parameters != null)
                foreach (var parameter in parameters)
                    dictionary[parameter.Key] = parameter.Value.ToString();

            var key = $"{UrlEncode(ConsumerSecret)}&{UrlEncode(string.IsNullOrWhiteSpace(AccessTokenSecret) ? "" : AccessTokenSecret)}";
            var message = $"{method.Method}&{UrlEncode(url)}&{UrlEncode(string.Join("&", AsUrlParameter(dictionary)))}";

            var hmacsha1 = new HMACSHA1 {Key = Encoding.ASCII.GetBytes(key)};
            var signature = Convert.ToBase64String(hmacsha1.ComputeHash(Encoding.ASCII.GetBytes(message)));
            var header = string.Join(",", AsUrlParameter(dictionary.Where(w => w.Key.StartsWith("oauth_"))));

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("OAuth", $"{header},oauth_signature={UrlEncode(signature)}");
        }

        private void PrepareForOAuth2()
        {
            if (!string.IsNullOrWhiteSpace(AccessToken))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
        }

        private static string GenerateTimestamp()
        {
            return Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds).ToString();
        }

        private static string GenerateNonce()
        {
            const string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var sb = new StringBuilder();
            var random = new Random();
            for (var i = 0; i < 32; i++)
                sb.Append(letters[random.Next(letters.Length)]);
            return sb.ToString();
        }

        private void ProcessLinkHeader(HttpResponseMessage response, object obj)
        {
            if (!response.Headers.Contains("link"))
                return;
            if (!(obj is IPagenator pagenator))
                return;

            var links = SimpleWebLinkParser.Parse(response.Headers.GetValues("link").FirstOrDefault());
            pagenator.Client = this;
            pagenator.First = links.FirstOrDefault(w => w.Rel == "first")?.Uri;
            pagenator.Next = links.FirstOrDefault(w => w.Rel == "next")?.Uri;
            pagenator.Prev = links.FirstOrDefault(w => w.Rel == "prev")?.Uri;
            pagenator.Last = links.FirstOrDefault(w => w.Rel == "last")?.Uri;
        }

        #region Utilities

        public static IEnumerable<string> AsUrlParameter<T>(IEnumerable<KeyValuePair<string, T>> parameters)
        {
            return parameters.Select(w => $"{w.Key}={UrlEncode(w.Value.ToString())}");
        }

        private static string UrlEncode(string str)
        {
            const string reservedLetters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
            var sb = new StringBuilder();
            foreach (var b in Encoding.UTF8.GetBytes(str))
                if (reservedLetters.Contains(((char) b).ToString()))
                    sb.Append((char) b);
                else
                    sb.Append($"%{b:X2}");
            return sb.ToString();
        }

        private static byte[] ReadAsByteArray(Stream stream)
        {
            var buffer = new byte[16 * 1024];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    ms.Write(buffer, 0, read);
                return ms.ToArray();
            }
        }

        #endregion

        #region HTTP Request

        /// <summary>
        ///     Send a GET request to endpoint with parameters.
        /// </summary>
        /// <typeparam name="T">JSON deserialized class.</typeparam>
        /// <param name="endpoint">Endpoint of API without base url.</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>API response deserialized to T</returns>
        public async Task<T> GetAsync<T>(string endpoint, IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            var response = await GetAsyncInternal(endpoint, parameters).Stay();
            var obj = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync().Stay());
            ProcessLinkHeader(response, obj);

            return obj;
        }

        /// <summary>
        ///     Send a GET request to endpoint with parameters.
        /// </summary>
        /// <param name="endpoint">Endpoint of API without base url.</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>API response</returns>
        public async Task<string> GetAsync(string endpoint, IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            var response = await GetAsyncInternal(endpoint, parameters).Stay();
            return await response.Content.ReadAsStringAsync().Stay();
        }

        private async Task<HttpResponseMessage> GetAsyncInternal(string endpoint, IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            PrepareForAuthenticate(HttpMethod.Get, _baseUrl + endpoint, parameters);
            if (parameters != null && parameters.Any())
                endpoint += $"?{string.Join("&", AsUrlParameter(parameters))}";

            var response = await _httpClient.GetAsync(_baseUrl + endpoint).Stay();
            response.EnsureSuccessStatusCode();

            return response;
        }

        /// <summary>
        ///     Send a POST request to endpoint with parameters.
        /// </summary>
        /// <typeparam name="T">JSON deserialized class.</typeparam>
        /// <param name="endpoint">Endpoint of API without base url.</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>API response deserialized to T</returns>
        public async Task<T> PostAsync<T>(string endpoint, IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            return await SendAsync<T>(HttpMethod.Post, endpoint, parameters).Stay();
        }

        /// <summary>
        ///     Send a POST request to endpoint with parameters.
        /// </summary>
        /// <param name="endpoint">Endpoint of API without base url.</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>API response</returns>
        public async Task<string> PostAsync(string endpoint, IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            return await SendAsync(HttpMethod.Post, endpoint, parameters).Stay();
        }

        /// <summary>
        ///     Send a PUT request to endpoint with parameters.
        /// </summary>
        /// <typeparam name="T">JSON deserialized class.</typeparam>
        /// <param name="endpoint">Endpoint of API without base url.</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>API response deserialized to T</returns>
        public async Task<T> PutAsync<T>(string endpoint, IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            return await SendAsync<T>(HttpMethod.Put, endpoint, parameters).Stay();
        }

        /// <summary>
        ///     Send a PUT request to endpoint with parameters.
        /// </summary>
        /// <param name="endpoint">Endpoint of API without base url.</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>API response</returns>
        public async Task<string> PutAsync(string endpoint, IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            return await SendAsync(HttpMethod.Put, endpoint, parameters);
        }

        /// <summary>
        ///     Send a DELETE request to endpoint with parameters.
        /// </summary>
        /// <typeparam name="T">JSON deserialized class.</typeparam>
        /// <param name="endpoint">Endpoint of API without base url.</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>API response deserialized to T</returns>
        public async Task<T> DeleteAsync<T>(string endpoint, IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            return JsonConvert.DeserializeObject<T>(await DeleteAsync(endpoint, parameters).Stay());
        }

        /// <summary>
        ///     Send a DELETE request to endpoint with parameters.
        /// </summary>
        /// <param name="endpoint">Endpoint of API without base url.</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>API response</returns>
        public async Task<string> DeleteAsync(string endpoint, IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            PrepareForAuthenticate(HttpMethod.Delete, _baseUrl + endpoint, parameters);
            if (parameters != null && parameters.Any())
                endpoint += $"?{string.Join("&", AsUrlParameter(parameters))}";

            var response = await _httpClient.DeleteAsync(_baseUrl + endpoint).Stay();
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync().Stay();
        }

        /// <summary>
        ///     Send a PATCH request to endpoint with parameters.
        /// </summary>
        /// <typeparam name="T">JSON deserialized class.</typeparam>
        /// <param name="endpoint">Endpoint of API without base url.</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>API response deserialized to T</returns>
        public async Task<T> PatchAsync<T>(string endpoint, IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            return await SendAsync<T>(new HttpMethod("PATCH"), endpoint, parameters).Stay();
        }

        /// <summary>
        ///     Send a PATCH request to endpoint with parameters.
        /// </summary>
        /// <param name="endpoint">Endpoint of API without base url.</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>API response</returns>
        public async Task<string> PatchAsync(string endpoint, IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            return await SendAsync(new HttpMethod("PATCH"), endpoint, parameters).Stay();
        }

        private async Task<T> SendAsync<T>(HttpMethod method, string endpoint, IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            var response = await SendAsyncInternal(method, endpoint, parameters).Stay();
            var obj = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync().Stay());

            ProcessLinkHeader(response, obj);
            return obj;
        }

        private async Task<string> SendAsync(HttpMethod method, string endpoint, IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            var response = await SendAsyncInternal(method, endpoint, parameters).Stay();
            return await response.Content.ReadAsStringAsync().Stay();
        }

        private async Task<HttpResponseMessage> SendAsyncInternal(HttpMethod method, string endpoint, IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            HttpContent content;
            if (parameters != null && parameters.Any(w => BinaryParameters.Contains(w.Key)))
            {
                PrepareForAuthenticate(method, _baseUrl + endpoint, new List<KeyValuePair<string, object>>());
                content = new MultipartFormDataContent();

                foreach (var parameter in parameters)
                {
                    HttpContent formDataContent;
                    if (BinaryParameters.Contains(parameter.Key))
                    {
                        using (var stream = new FileStream(parameter.Value.ToString(), FileMode.Open))
                            formDataContent = new ByteArrayContent(ReadAsByteArray(stream));
                        formDataContent.Headers.Add("Content-Disposition", $"form-data; name=\"{parameter.Key}\"; filename=\"{Path.GetFileName(parameter.Value.ToString())}\"");
                    }
                    else
                    {
                        formDataContent = new StringContent(parameter.Value.ToString());
                    }
                    ((MultipartFormDataContent) content).Add(formDataContent, parameter.Key);
                }
            }
            else
            {
                PrepareForAuthenticate(method, _baseUrl + endpoint, parameters);
                var kvpCollection = parameters?.Select(w => new KeyValuePair<string, string>(w.Key, w.Value.ToString()));
                content = new FormUrlEncodedContent(kvpCollection);
            }

            var response = await _httpClient.SendAsync(new HttpRequestMessage(method, _baseUrl + endpoint) {Content = content}).Stay();
            response.EnsureSuccessStatusCode();

            return response;
        }

        #endregion

        #region Application Keys

        /// <summary>
        ///     Client ID
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        ///     Client Secret
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        ///     Consumer Key (alias of <see cref="ClientId" />)
        /// </summary>
        public string ConsumerKey
        {
            get => ClientId;
            set => ClientId = value;
        }

        /// <summary>
        ///     Consumer secret (alias of <see cref="ClientSecret" />)
        /// </summary>
        public string ConsumerSecret
        {
            get => ClientSecret;
            set => ClientSecret = value;
        }

        #endregion

        #region User Keys

        /// <summary>
        ///     Access Token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        ///     Access Token Secret
        /// </summary>
        public string AccessTokenSecret { get; set; }

        /// <summary>
        ///     Refresh Token (OAuth 2.0)
        /// </summary>
        public string RefreshToken { get; set; }

        #endregion
    }
}