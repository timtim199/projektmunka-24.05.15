using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace kutya_desktop.Data.Models
{
    public class Animal
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
    }
}
