using Microsoft.EntityFrameworkCore;
using System.Data;

namespace kutya_sajat_api.Data.Models
{
    public interface IModel
    {
        public void IncludeAll<T>(DbSet<T> db) where T : class;
    }
}
