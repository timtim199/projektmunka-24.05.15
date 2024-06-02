using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kutya_desktop.Data.Models;

namespace kutya_desktop.Data.Api
{
    internal class AnimalApiClient : IApiClient<Animal>
    {
        private readonly ApiClient _apiClient;

        public AnimalApiClient(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<Animal> GetAsync(int id)
        {
            return _apiClient.GetAsync<Animal>($"/api/animals/{id}");
        }

        public Task CreateAsync(Animal entity)
        {
            return _apiClient.PostAsync("/api/animals", entity);
        }

        public Task UpdateAsync(int id, Animal entity)
        {
            return _apiClient.PutAsync($"/api/animals/{id}", entity);
        }

        public Task DeleteAsync(int id)
        {
            return _apiClient.DeleteAsync($"/api/animals/{id}");
        }

        public async Task<IEnumerable<Animal>> GetPageAsync(int pageNum)
        {
            return await _apiClient.GetAsync<List<Animal>>($"/api/animals/page/{pageNum}");
        }
    }
}
