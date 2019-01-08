using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Client
{
    public class RestClient : IDisposable
    {
        private const string BaseUrl = "http://localhost:5000";
        private readonly HttpClient _httpClient;

        public RestClient()
        {
            _httpClient = new HttpClient {BaseAddress = new Uri(BaseUrl)};
        }

        public async Task<T> GetAsync<T>(string path)
        {
            var response = await _httpClient.GetAsync(path);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception();
            }

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }

        public async Task<string> PostAsync(string path, object data = null)
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(path, content);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception();
            }

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        public async Task<T> PostAsync<T>(string path, object data = null)
        {
            var result = await PostAsync(path, data);
            return JsonConvert.DeserializeObject<T>(result);
        }

        public async Task DeleteAsync(string path)
        {
            var response = await _httpClient.DeleteAsync(path);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception();
            }
            
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}