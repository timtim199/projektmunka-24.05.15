using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kutya_desktop.Data.Models;

namespace kutya_desktop.Data.Api
{
    internal class OwnerApiClient : IApiClient<Owner>
    {
        private readonly ApiClient _apiClient;

        public OwnerApiClient(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<Owner> GetAsync(int id)
        {
            return _apiClient.GetAsync<Owner>($"/api/owners/{id}");
        }

        public Task CreateAsync(Owner entity)
        {
            return _apiClient.PostAsync("/api/animals", entity);
        }

        public Task UpdateAsync(int id, Owner entity)
        {
            return _apiClient.PutAsync($"/api/animals/{id}", entity);
        }

        public Task DeleteAsync(int id)
        {
            return _apiClient.DeleteAsync($"/api/animals/{id}");
        }

        public async Task<IEnumerable<Owner>> GetPageAsync(int pageNum)
        {
            return await _apiClient.GetAsync<List<Owner>>($"/api/owners/page/{pageNum}");
        }

        public async Task<IEnumerable<Owner>> SearchAsync(SearchDto dto)
        {
            return await _apiClient.PatchAsync<List<Owner>>($"/api/owners/search", dto);
        }
    }
}
