using kutya_sajat_api.Data.Models.NonDatabase;
using System;
using System.Collections.Generic;

#nullable enable
namespace kutya_sajat_api.Data.Models.DataTransferObjects
{
    public class BreedDto : IDataTransferObject<Breed>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public static BreedDto GetAsTransferObject(Breed breed)
        {
            return new BreedDto()
            {
                Name = breed.Name,
                Description = breed.Description,
            };
        }

        Breed IDataTransferObject<Breed>.GetAsDatabaseModel()
        {
            if (!String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(Description))
            {
                return new Breed()
                {
                    Name = this.Name,
                    Description = this.Description,
                };
            }
            else
            {
                throw new ServiceExceptionResult<BreedDto>("Model validation failed", data: this);
            }
        }

        public Breed ParseIntoDatabaseModel(Breed model)
        {
            if (!String.IsNullOrEmpty(Name))
            {
                model.Name = this.Name;
            }

            if (!String.IsNullOrEmpty(Description))
            {
                model.Description = this.Description;
            }
            return model;
        }
    }
}
