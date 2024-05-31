using kutya_sajat_api.Data.Models.NonDatabase;
using System;
using System.Collections.Generic;

#nullable enable
namespace kutya_sajat_api.Data.Models.DataTransferObjects
{
    public class OwnerDto : IDataTransferObject<Owner>
    {
        public string? Name { get; set; }
        public string? IdCardNumber { get; set; }

        public static OwnerDto GetAsTransferObject(Owner owner)
        {
            return new OwnerDto()
            {
                Name = owner.Name,
                IdCardNumber = owner.IdCardNumber,
            };
        }

        Owner IDataTransferObject<Owner>.GetAsDatabaseModel()
        {
            if (!String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(IdCardNumber))
            {
                return new Owner()
                {
                    Name = this.Name,
                    IdCardNumber = this.IdCardNumber,
                };
            }
            else
            {
                throw new ServiceExceptionResult<OwnerDto>("Model validation failed", data: this);
            }
        }

        public Owner ParseIntoDatabaseModel(Owner model)
        {
            if (!String.IsNullOrEmpty(Name))
            {
                model.Name = this.Name;
            }

            if (!String.IsNullOrEmpty(IdCardNumber))
            {
                model.IdCardNumber = this.IdCardNumber;
            }

            return model;
        }
    }
}
