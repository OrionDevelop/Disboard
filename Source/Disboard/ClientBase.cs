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

using Newtonsoft.Json;

// ReSharper disable UnusedParameter.Local
// ReSharper disable PossibleMultipleEnumeration

namespace Disboard
{
    /// <summary>
    ///     Client Base Implementation
    /// </summary>
    public class ClientBase
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
        protected ClientBase(string baseUrl, string version)
        {
            _baseUrl = baseUrl;
            _version = version;

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", $"Disboard/{Version}");
        }

        #region HTTP Request

        /// <summary>
        ///     Send a GET request to endpoint with parameters.
        /// </summary>
        /// <typeparam name="T">JSON deserialized class.</typeparam>
        /// <param name="endpoint">Endpoint of API without base url.</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>API response deserialized to T</returns>
        public async Task<T> GetAsync<T>(string endpoint, IEnumerable<KeyValuePair<string, object>> parameters)
        {
            return JsonConvert.DeserializeObject<T>(await GetAsync(endpoint, parameters).Stay());
        }

        /// <summary>
        ///     Send a GET request to endpoint with parameters.
        /// </summary>
        /// <param name="endpoint">Endpoint of API without base url.</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>API response</returns>
        public async Task<string> GetAsync(string endpoint, IEnumerable<KeyValuePair<string, object>> parameters)
        {
            PrepareForAuthenticate(HttpMethod.Get, _baseUrl + endpoint, parameters);
            if (parameters != null && parameters.Any())
                endpoint += $"?{string.Join("&", AsUrlParameter(parameters))}";

            var response = await _httpClient.GetAsync(_baseUrl + endpoint).Stay();
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync().Stay();
        }

        /// <summary>
        ///     Send a POST request to endpoint with parameters.
        /// </summary>
        /// <typeparam name="T">JSON deserialized class.</typeparam>
        /// <param name="endpoint">Endpoint of API without base url.</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>API response deserialized to T</returns>
        public async Task<T> PostAsync<T>(string endpoint, IEnumerable<KeyValuePair<string, object>> parameters)
        {
            return await SendAsync<T>(HttpMethod.Post, endpoint, parameters).Stay();
        }

        /// <summary>
        ///     Send a POST request to endpoint with parameters.
        /// </summary>
        /// <param name="endpoint">Endpoint of API without base url.</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>API response</returns>
        public async Task<string> PostAsync(string endpoint, IEnumerable<KeyValuePair<string, object>> parameters)
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
        public async Task<T> PutAsync<T>(string endpoint, IEnumerable<KeyValuePair<string, object>> parameters)
        {
            return await SendAsync<T>(HttpMethod.Put, endpoint, parameters).Stay();
        }

        /// <summary>
        ///     Send a PUT request to endpoint with parameters.
        /// </summary>
        /// <param name="endpoint">Endpoint of API without base url.</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>API response</returns>
        public async Task<string> PutAsync(string endpoint, IEnumerable<KeyValuePair<string, object>> parameters)
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
        public async Task<T> DeleteAsync<T>(string endpoint, IEnumerable<KeyValuePair<string, object>> parameters)
        {
            return JsonConvert.DeserializeObject<T>(await DeleteAsync(endpoint, parameters).Stay());
        }

        /// <summary>
        ///     Send a DELETE request to endpoint with parameters.
        /// </summary>
        /// <param name="endpoint">Endpoint of API without base url.</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>API response</returns>
        public async Task<string> DeleteAsync(string endpoint, IEnumerable<KeyValuePair<string, object>> parameters)
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
        public async Task<T> PatchAsync<T>(string endpoint, IEnumerable<KeyValuePair<string, object>> parameters)
        {
            return await SendAsync<T>(new HttpMethod("PATCH"), endpoint, parameters).Stay();
        }

        /// <summary>
        ///     Send a PATCH request to endpoint with parameters.
        /// </summary>
        /// <param name="endpoint">Endpoint of API without base url.</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>API response</returns>
        public async Task<string> PatchAsync(string endpoint, IEnumerable<KeyValuePair<string, object>> parameters)
        {
            return await SendAsync(new HttpMethod("PATCH"), endpoint, parameters).Stay();
        }

        private async Task<T> SendAsync<T>(HttpMethod method, string endpoint, IEnumerable<KeyValuePair<string, object>> parameters)
        {
            return JsonConvert.DeserializeObject<T>(await SendAsync(method, endpoint, parameters).Stay());
        }

        private async Task<string> SendAsync(HttpMethod method, string endpoint, IEnumerable<KeyValuePair<string, object>> parameters)
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
                        formDataContent = new StreamContent(new FileStream(parameter.Value.ToString(), FileMode.Open));
                        formDataContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                        formDataContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                        {
                            FileName = $"\"{Path.GetFileName(parameter.Value.ToString())}\""
                        };
                    }
                    else
                    {
                        formDataContent = new StringContent(UrlEncode(parameter.Value.ToString()));
                    }
                    ((MultipartFormDataContent)content).Add(formDataContent, parameter.Key);
                }
            }
            else
            {
                PrepareForAuthenticate(method, _baseUrl + endpoint, parameters);
                var kvpCollection = parameters?.Select(w => new KeyValuePair<string, string>(w.Key, w.Value.ToString()));
                content = new FormUrlEncodedContent(kvpCollection);
            }

            var response = await _httpClient.SendAsync(new HttpRequestMessage(method, _baseUrl + endpoint) { Content = content }).Stay();
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync().Stay();
        }

        #endregion

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

        private static IEnumerable<string> AsUrlParameter<T>(IEnumerable<KeyValuePair<string, T>> parameters)
        {
            return parameters.Select(w => $"{w.Key}={UrlEncode(w.Value.ToString())}");
        }

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