using kutya_desktop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutya_desktop.Data.Api
{
    public class BreedApiClient
    {
        private readonly ApiClient _apiClient;

        public BreedApiClient(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<Breed> GetBreedAsync(int id)
        {
            return _apiClient.GetAsync<Breed>($"/api/breeds/{id}");
        }

        public Task CreateBreedAsync(Breed breed)
        {
            return _apiClient.PostAsync("/api/breeds", breed);
        }

        public Task UpdateBreedAsync(int id, Breed breed)
        {
            return _apiClient.PutAsync($"/api/breeds/{id}", breed);
        }

        public Task DeleteBreedAsync(int id)
        {
            return _apiClient.DeleteAsync($"/api/breeds/{id}");
        }

        public async Task<IEnumerable<Breed>> GetBreedsByPageAsync(int pageNum)
        {
            return await _apiClient.GetAsync<List<Breed>>($"/api/breeds/page/{pageNum}");
        }
    }

}
