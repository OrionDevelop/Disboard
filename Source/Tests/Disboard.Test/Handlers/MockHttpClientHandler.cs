using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Disboard.Test.Handlers
{
    public class MockHttpClientHandler : HttpClientHandler
    {
        private readonly string _salt;

        public MockHttpClientHandler(string salt = "")
        {
            _salt = salt;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var path = Path.Combine("./data", $"{await CreateRequestHash(request)}.json");

            // If dump file exists, use dumped HTTP response.
            if (File.Exists(path))
                using (var sr = new StreamReader(path))
                    return new HttpResponseMessage(HttpStatusCode.OK) {Content = new StringContent(await sr.ReadToEndAsync())};

#if DEBUG
            var response = await base.SendAsync(request, cancellationToken);
            using (var sw = new StreamWriter(path))
                sw.WriteLine(await response.Content.ReadAsStringAsync());
            await UpdateMapper(request);
            return response;
#else
            throw new InvalidOperationException();
#endif
        }

        private async Task<string> CreateRequestHash(HttpRequestMessage request)
        {
            var method = request.Method.Method;
            var endpoint = request.RequestUri.ToString();
            var body = request.Content != null ? await request.Content.ReadAsStringAsync() : "";

            var md5 = CalcMd5(method + endpoint + body);
            return md5;
        }

        private string CalcMd5(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str + _salt);
            var sha256 = new MD5CryptoServiceProvider();

            return string.Join("", sha256.ComputeHash(bytes).Select(w => $"{w:x2}"));
        }

        private async Task UpdateMapper(HttpRequestMessage request)
        {
            var path = Path.Combine("./data", "mapping.json");
            var hash = await CreateRequestHash(request);
            var query = $"{request.Method.Method} {request.RequestUri.PathAndQuery}";

            var json = "";
            if (File.Exists(path))
                using (var sr = new StreamReader(path))
                    json = await sr.ReadToEndAsync();
            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json) ?? new Dictionary<string, string>();
            if (dict.ContainsKey(hash))
                return;
            dict[hash] = query;

            using (var sw = new StreamWriter(path))
                await sw.WriteLineAsync(JsonConvert.SerializeObject(new SortedDictionary<string, string>(dict)));
        }
    }
}