using kutya_desktop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutya_desktop.Data.Api
{
    public class BreedApiClient : IApiClient<Breed>
    {
        private readonly ApiClient _apiClient;

        public BreedApiClient(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<Breed> GetAsync(int id)
        {
            return _apiClient.GetAsync<Breed>($"/api/breeds/{id}");
        }

        public Task CreateAsync(Breed entity)
        {
            return _apiClient.PostAsync("/api/breeds", entity);
        }

        public Task UpdateAsync(int id, Breed entity)
        {
            return _apiClient.PutAsync($"/api/breeds/{id}", entity);
        }

        public Task DeleteAsync(int id)
        {
            return _apiClient.DeleteAsync($"/api/breeds/{id}");
        }

        public async Task<IEnumerable<Breed>> GetPageAsync(int pageNum)
        {
            return await _apiClient.GetAsync<List<Breed>>($"/api/breeds/page/{pageNum}");
        }
    }

}
