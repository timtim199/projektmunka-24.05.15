using kutya_sajat_api.Data.Models;
using kutya_sajat_api.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection.Emit;

namespace kutya_sajat_api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }

        public string DbPath { get => GetDbPath(); }

        private object[] datasets = new object[4];

        public ApplicationDbContext()
        {
            InitDatasets();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Seed(100);

            InitForeignKeys(builder);
        }

        private string GetDbPath()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            path = "database.db";//System.IO.Path.Join(path, "database.db");
            Console.WriteLine(path);
            return path;
        }

        private void InitForeignKeys(ModelBuilder builder)
        {
            builder.Entity<Animal>()
                .HasOne(a => a.Breed)
                .WithMany(b => b.Animals)
                .HasForeignKey(a => a.BreedId);

            builder.Entity<Animal>()
                .HasOne(a => a.Owner)
                .WithMany(b => b.Animals)
                .HasForeignKey(a => a.OwnerId);

            builder.Entity<MedicalRecord>()
                .HasOne(a => a.Animal)
                .WithMany(b => b.MedicalRecords)
                .HasForeignKey(a => a.AnimalId);
        }

        private void InitDatasets()
        {
            datasets = new object[4]
            {
                Animals, Breeds, Owners, MedicalRecords
            };
        }

        public DbSet<T> GetDb<T>() where T : class, IModel
        {
            foreach (var dataset in datasets)
            {
                if (dataset is DbSet<T>)
                {
                    return dataset as DbSet<T>;
                }
            }
            
            
            throw new Exception($"Dataset of {nameof(T)} not found!");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
