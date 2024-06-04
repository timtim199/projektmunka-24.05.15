using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kutya_desktop.Data.Models;

namespace kutya_desktop.Data.Api
{
    internal class MedicalRecordApiClient : IApiClient<MedicalRecord>
    {
        private readonly ApiClient _apiClient;

        public MedicalRecordApiClient(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<MedicalRecord> GetAsync(int id)
        {
            return _apiClient.GetAsync<MedicalRecord>($"/api/medicalrecords/{id}");
        }

        public Task CreateAsync(MedicalRecord entity)
        {
            return _apiClient.PostAsync("/api/medicalrecords", entity);
        }

        public Task UpdateAsync(int id, MedicalRecord entity)
        {
            return _apiClient.PutAsync($"/api/medicalrecords/{id}", entity);
        }

        public Task DeleteAsync(int id)
        {
            return _apiClient.DeleteAsync($"/api/medicalrecords/{id}");
        }

        public async Task<IEnumerable<MedicalRecord>> GetPageAsync(int pageNum)
        {
            return await _apiClient.GetAsync<List<MedicalRecord>>($"/api/medicalrecords/page/{pageNum}");
        }

        public async Task<IEnumerable<MedicalRecord>> SearchAsync(SearchDto dto)
        {
            return await _apiClient.PatchAsync<List<MedicalRecord>>($"/api/medicalrecords/search", dto);
        }
    }
}
