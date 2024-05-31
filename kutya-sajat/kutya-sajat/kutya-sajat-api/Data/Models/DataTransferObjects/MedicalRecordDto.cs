using kutya_sajat_api.Data.Models.NonDatabase;
using System;

#nullable enable
namespace kutya_sajat_api.Data.Models.DataTransferObjects
{
    public class MedicalRecordDto : IDataTransferObject<MedicalRecord>
    {
        public string? Description { get; set; }
        public int? AnimalId { get; set; }

        public static MedicalRecordDto GetAsTransferObject(MedicalRecord medicalRecord)
        {
            return new MedicalRecordDto()
            {
                Description = medicalRecord.Description,
                AnimalId = medicalRecord.AnimalId
            };
        }

        MedicalRecord IDataTransferObject<MedicalRecord>.GetAsDatabaseModel()
        {
            if (!string.IsNullOrEmpty(Description) && AnimalId.HasValue)
            {
                return new MedicalRecord()
                {
                    Description = Description,
                    AnimalId = (int)AnimalId
                };
            }
            else
            {
                throw new ServiceExceptionResult<MedicalRecordDto>("Model validation failed", data: this);
            }
        }

        public MedicalRecord ParseIntoDatabaseModel(MedicalRecord model)
        {
            if (!string.IsNullOrEmpty(Description))
            {
                model.Description = Description;
            }

            if (AnimalId.HasValue)
            {
                model.AnimalId = (int)AnimalId;
            }

            return model;
        }
    }
}
