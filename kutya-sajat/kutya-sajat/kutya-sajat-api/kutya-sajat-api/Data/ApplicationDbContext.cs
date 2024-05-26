using kutya_sajat_api.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace kutya_sajat_api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }

        public string DbPath { get; }

        public ApplicationDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = "database.db";//System.IO.Path.Join(path, "database.db");
            Console.WriteLine(DbPath);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
