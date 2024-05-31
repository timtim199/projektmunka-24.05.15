using kutya_desktop.Data.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace kutya_desktop.Data.Api
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        private JsonSerializerOptions serializerOptions => new JsonSerializerOptions() 
        { 
            PropertyNameCaseInsensitive = true, 
            ReferenceHandler = ReferenceHandler.Preserve
        };

        public ApiClient(string baseUrl)
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl;
        }

        private StringContent GetContent(object data)
        {
            return new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}{endpoint}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();

            var dto = JsonSerializer.Deserialize<ResponseDto<T>>(jsonResponse, serializerOptions) ;;
            return dto.Data;
        }

        public async Task PostAsync<T>(string endpoint, T data)
        {
            var response = await _httpClient.PostAsync($"{_baseUrl}{endpoint}", GetContent(data));
            response.EnsureSuccessStatusCode();
        }

        public async Task PutAsync<T>(string endpoint, T data)
        {
            var response = await _httpClient.PutAsync($"{_baseUrl}{endpoint}", GetContent(data));
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(string endpoint)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}{endpoint}");
            response.EnsureSuccessStatusCode();
        }
    }
}
