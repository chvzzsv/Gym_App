using Gym_App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gym_App.Services
{
    public class Client
    {
        private readonly HttpClient _httpClient;

        public Client()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://productosgymunivo-default-rtdb.firebaseio.com/");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("Products.json");
            response.EnsureSuccessStatusCode();

            string responseData = await response.Content.ReadAsStringAsync();

            // Imprimir el JSON recibido para depuración
            System.Diagnostics.Debug.WriteLine(responseData);

            Dictionary<string, Product> productsDictionary = JsonConvert.DeserializeObject<Dictionary<string, Product>>(responseData);

            return productsDictionary.Values.ToList();
        }


        public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, object data)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(endpoint, content);
            response.EnsureSuccessStatusCode(); // Throw if not a success code.

            string responseData = await response.Content.ReadAsStringAsync();
            TResponse tResponse = JsonConvert.DeserializeObject<TResponse>(responseData);

            return tResponse;
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(string endpoint, object data)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync(endpoint, content);
            response.EnsureSuccessStatusCode();

            string responseData = await response.Content.ReadAsStringAsync();
            TResponse tResponse = JsonConvert.DeserializeObject<TResponse>(responseData);

            return tResponse;
        }

        public async Task<TResponse> PatchAsync<TRequest, TResponse>(string endpoint, object data)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("PATCH"), endpoint) { Content = content };

            HttpResponseMessage response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string responseData = await response.Content.ReadAsStringAsync();
            TResponse tResponse = JsonConvert.DeserializeObject<TResponse>(responseData);

            return tResponse;
        }

        public async Task DeleteAsync(string endpoint)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(endpoint);
            response.EnsureSuccessStatusCode();
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}

