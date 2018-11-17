using System.Collections.Generic;
using System.Threading.Tasks;

using Disboard.Extensions;

namespace Disboard.Clients
{
    public class ApiClient<T> where T : AppClient
    {
        private readonly string _base;
        protected T Client { get; }

        protected ApiClient(T client, string @base)
        {
            Client = client;
            _base = @base;
        }

        protected async Task<TR> GetAsync<TR>(string endpoint = "", IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            return await Client.GetAsync<TR>(_base + endpoint, parameters).Stay();
        }

        protected async Task<string> GetAsync(string endpoint = "", IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            return await Client.GetAsync(_base + endpoint, parameters).Stay();
        }

        protected async Task<TR> PostAsync<TR>(string endpoint = "", IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            return await Client.PostAsync<TR>(_base + endpoint, parameters).Stay();
        }

        protected async Task<string> PostAsync(string endpoint = "", IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            return await Client.PostAsync(_base + endpoint, parameters).Stay();
        }

        protected async Task<TR> PatchAsync<TR>(string endpoint = "", IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            return await Client.PatchAsync<TR>(_base + endpoint, parameters).Stay();
        }

        protected async Task<string> PatchAsync(string endpoint = "", IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            return await Client.PatchAsync(_base + endpoint, parameters).Stay();
        }

        protected async Task<TR> PutAsync<TR>(string endpoint = "", IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            return await Client.PutAsync<TR>(_base + endpoint, parameters).Stay();
        }

        protected async Task<string> PutAsync(string endpoint = "", IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            return await Client.PutAsync(_base + endpoint, parameters).Stay();
        }

        protected async Task<TR> DeleteAsync<TR>(string endpoint = "", IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            return await Client.DeleteAsync<TR>(_base + endpoint, parameters).Stay();
        }

        protected async Task<string> DeleteAsync(string endpoint = "", IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            return await Client.DeleteAsync(_base + endpoint, parameters).Stay();
        }
    }
}