using kutya_sajat_api.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Bogus.DataSets;

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

        [JsonIgnore]
        public virtual List<MedicalRecord> MedicalRecords { get; set; }

        public void IncludeAll(DbContext context)
        {
            context.Entry(this).Reference(x => x.Breed).Load();
            context.Entry(this).Reference(x => x.Owner).Load();
            context.Entry(this).Collection(x => x.MedicalRecords).Load();
        }

        public override string ToString()
        {
            return $"{AnimalId}{Name}{DateOfBirth}{Breed.Name}{Owner.Name}";
        }
    }
}
