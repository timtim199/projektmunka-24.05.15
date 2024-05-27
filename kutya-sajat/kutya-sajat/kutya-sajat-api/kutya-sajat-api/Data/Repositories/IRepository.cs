using System;
using System.Collections;
using System.Collections.Generic;

namespace kutya_sajat_api.Data.Repositories
{
    public interface IRepository<T>
    {
        public IEnumerable<T> Where(Func<T, bool> predicate);
        public IEnumerable<T> GetPage(uint pageNumber);
        public T FindId(int id);
        public void Insert(T entity);
        public void Delete(T entity);
        public void Update(T entity);
        public void Save();
    }
}
