using kutya_sajat_api.Data.Models.NonDatabase;
using System;

#nullable enable
namespace kutya_sajat_api.Data.Models.DataTransferObjects
{
    public class AnimalDto : IDataTransferObject<Animal>
    {
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? BreedId { get; set; }
        public int? OwnerId { get; set; }

        public static AnimalDto GetAsTransferObject(Animal animal)
        {
            return new AnimalDto()
            {
                Name = animal.Name,
                DateOfBirth = animal.DateOfBirth,
                OwnerId = animal.OwnerId,
                BreedId = animal.BreedId
            };
        }

        Animal IDataTransferObject<Animal>.GetAsDatabaseModel()
        {
            if(!String.IsNullOrEmpty(Name) && DateOfBirth.HasValue && BreedId.HasValue && OwnerId.HasValue)
            {
                return new Animal()
                {
                    Name = this.Name,
                    DateOfBirth = (DateTime)DateOfBirth,
                    OwnerId = (int)OwnerId,
                    BreedId = (int)BreedId
                };
            }
            else
            {
                throw new ServiceExceptionResult<AnimalDto>("Model validation failed", data: this);
            }
            
        }

        public Animal ParseIntoDatabaseModel(Animal model)
        {
            if(!String.IsNullOrEmpty(Name))
            {
                model.Name = this.Name;
            }

            if(DateOfBirth.HasValue)
            {
                model.DateOfBirth = (DateTime)DateOfBirth;
            }

            if (OwnerId.HasValue)
            {
                model.OwnerId = (int)OwnerId;
            }

            if (BreedId.HasValue)
            {
                model.BreedId = (int)BreedId;
            }

            return model;
        }

    }
}
