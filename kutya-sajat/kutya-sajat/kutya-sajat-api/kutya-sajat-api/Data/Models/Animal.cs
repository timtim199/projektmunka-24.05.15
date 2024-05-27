using Microsoft.EntityFrameworkCore;
using System;

namespace kutya_sajat_api.Data.Models
{
    public class Animal : IModel
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int BreedId { get; set; }
        public virtual Breed Breed { get; set; }

        public int OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        void IModel.IncludeAll<T>(DbSet<T> db) where T : class
        {
            (db as DbSet<Animal>).Include(x => x.Owner);
            (db as DbSet<Animal>).Include(x => x.Breed);
        }

    }
}
