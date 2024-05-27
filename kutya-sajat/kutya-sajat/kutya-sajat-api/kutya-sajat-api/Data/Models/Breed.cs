using Microsoft.EntityFrameworkCore;

namespace kutya_sajat_api.Data.Models
{
    public class Breed : IModel
    {
        public int BreedId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void IncludeAll<T>(DbSet<T> db) where T : class
        {
            throw new System.NotImplementedException();
        }
    }
}
