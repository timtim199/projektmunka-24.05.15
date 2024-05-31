using kutya_sajat_api.Data.Models;
using kutya_sajat_api.Data.Models.DataTransferObjects;
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
        protected readonly DbSet<T> db;
        protected ApplicationDbContext context;

        public Repository(ApplicationDbContext _applicationDbContext)
        {
            db = _applicationDbContext.GetDb<T>();
            context = _applicationDbContext;
        }

        public void DeleteById(int id, bool saveChanges = true)
            => Delete(FindId(id));

        public void Delete(T entity, bool saveChanges = true)
        {
            db.Remove(entity);
            if(saveChanges)
            {
                Save();
            }
        }

        public T FindId(int id, bool includeAll = false)
        {
            T result = db.Find(id);
            
            if (result == null)
            {
                throw new ServiceExceptionResult<string>($"{typeof(T)}: Id not found", 404, data: $"{typeof(T)}: Id not found");
            }

            if (includeAll)
            {
                result.IncludeAll(context);
            }
            return result;
        }

        public IEnumerable<T> GetPage(uint pageNumber)
        {
            return db.Skip(pageSize * (int)pageNumber).Take(30).ToList();
        }

        public T Insert(IDataTransferObject<T> dto, bool saveChanges = true)
        {
            T entity = dto.GetAsDatabaseModel();
            db.Add(entity);
            if(saveChanges)
            {
                Save();
            }
            return entity;
        }

        public void Insert(T entity)
        {
            db.Add(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public T Update(int id, IDataTransferObject<T> dto, bool saveChanges = true)
        {
            T entity = db.Find(id);
            dto.ParseIntoDatabaseModel(entity);
            db.Update(entity);
            if (saveChanges)
            {
                Save();
            }
            return entity;
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<T> Where(Func<T, bool> predicate)
        {
            return db.Where(predicate);
        }

        public T IncludeAll(T entity)
        {
            entity.IncludeAll(context);
            return entity;
        }
    }
}
