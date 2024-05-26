using System;

namespace kutya_sajat_api.Data.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int BreedId { get; set; }
        public Breed Breed { get; set; }

        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}
