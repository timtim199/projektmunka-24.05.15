using kutya_sajat_api.Data.Models;
using kutya_sajat_api.Data.Models.NonDatabase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace kutya_sajat_api.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IModel
    {
        private const int pageSize = 30;
        private readonly DbSet<T> db;
        private ApplicationDbContext context;

        public Repository(ApplicationDbContext _applicationDbContext)
        {
            db = _applicationDbContext.GetDb<T>();
        }

        public void Delete(T entity)
        {
            db.Remove(entity);
        }

        public T FindId(int id)
        {
            T result = db.Find(id);
            if (result == null)
            {
                throw new ServiceExceptionResult<string>($"{typeof(T)}: Id not found", 404, data: $"{typeof(T)}: Id not found");
            }
            result.IncludeAll<T>(db);
            result = db.Find(id);

            return result;
        }

        public IEnumerable<T> GetPage(uint pageNumber)
        {
            return db.Skip(pageSize * (int)pageNumber).Take(30).ToList();
        }

        public void Insert(T entity)
        {
            db.Add(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<T> Where(Func<T, bool> predicate)
        {
            return db.Where(predicate);
        }
    }
}
