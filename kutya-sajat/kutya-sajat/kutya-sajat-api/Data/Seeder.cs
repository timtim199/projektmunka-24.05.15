//https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding
//https://github.com/bchavez/Bogus


using Bogus;
using Bogus.DataSets;
using kutya_sajat_api.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace kutya_sajat_api.Data
{
    public static class Seeder
    {
        private static List<Breed> _breeds;
        private static List<Owner> _owners;
        private static List<Animal> _animals;
        private static List<MedicalRecord> _medicalRecords;
        private static int sequences;

        static Seeder()
        {
            Randomizer.Seed = new Random(54456645);
        }

        public static ModelBuilder Seed(this ModelBuilder modelBuilder, int _sequences)
        {
            sequences= _sequences;
            SeedBreeds(modelBuilder);
            SeedOwners(modelBuilder);
            SeedAnimals(modelBuilder);
            SeedMedicalRecords(modelBuilder);
            return modelBuilder;
        }

        private static void SeedBreeds(ModelBuilder builder)
        {
            _breeds = GenerateBreeds();
            builder.Entity<Breed>().HasData(_breeds);
        }

        private static void SeedOwners(ModelBuilder builder)
        {
            _owners = GenerateOwners();
            builder.Entity<Owner>().HasData(_owners);
        }

        private static void SeedAnimals(ModelBuilder builder)
        {
            _animals = GenerateAnimals();
            builder.Entity<Animal>().HasData(_animals);
        }

        private static void SeedMedicalRecords(ModelBuilder builder)
        {
            _medicalRecords = GenerateMedicalRecords();
            builder.Entity<MedicalRecord>().HasData(_medicalRecords);
        }


        private static List<Breed> GenerateBreeds()
        {
            int breedId = 1;
            var breeds = new Faker<Breed>()
                .RuleFor(b => b.BreedId, f => breedId++)
                .RuleFor(b => b.Name, f => f.Name.LastName())
                .RuleFor(b => b.Description, f => f.Lorem.Text())
                .Generate(CalculateSequence(75));

            return breeds;
        }

        private static List<Owner> GenerateOwners()
        {
            int ownerId = 1;
            var owners = new Faker<Owner>()
                .RuleFor(b => b.OwnerId, f => ownerId++)
                .RuleFor(b => b.Name, f => f.Name.FullName())
                .RuleFor(b => b.IdCardNumber, f => Guid.NewGuid().ToString())
                .Generate(CalculateSequence(85));

            return owners;
        }

        private static List<MedicalRecord> GenerateMedicalRecords()
        {
            int recordId = 1;
            var records = new Faker<MedicalRecord>()
                .RuleFor(b => b.MedicalRecordId, f => recordId++)
                .RuleFor(b => b.CreatedAt, f => f.Date.Between(DateTime.MinValue.AddYears(1900), DateTime.Now))
                .RuleFor(b => b.Description, f => f.Lorem.Text())
                .RuleFor(b => b.AnimalId, f => f.PickRandom(_animals).AnimalId)

                .Generate(CalculateSequence(300));

            return records;
        }

        private static List<Animal> GenerateAnimals()
        {
            int animalId = 1;
            var animals = new Faker<Animal>()
                .RuleFor(b => b.AnimalId, f => animalId++)
                .RuleFor(b => b.DateOfBirth, f => f.Date.Between(DateTime.MinValue.AddYears(1900), DateTime.Now))
                .RuleFor(b => b.Name, f => f.Name.FirstName())
                .RuleFor(b => b.BreedId, f => f.PickRandom(_breeds).BreedId)
                .RuleFor(b => b.OwnerId, f => f.PickRandom(_owners).OwnerId)

                .Generate(CalculateSequence());

            return animals;
        }

        private static int CalculateSequence(decimal percentage = 100)
            => (int)Math.Ceiling((decimal)sequences * (percentage / 100));
    }
}
