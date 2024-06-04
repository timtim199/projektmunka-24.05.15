using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kutya_desktop.Data.Models;

namespace kutya_desktop.Data.Api
{
    public interface IApiClient<T>
    {
        public Task<T> GetAsync(int id);
        public Task CreateAsync(T entity);
        public Task DeleteAsync(int id);
        public Task UpdateAsync(int id, T entity);
        public Task<IEnumerable<T>> GetPageAsync(int pageNum);
        public Task<IEnumerable<T>> SearchAsync(SearchDto dto);
    }
}
