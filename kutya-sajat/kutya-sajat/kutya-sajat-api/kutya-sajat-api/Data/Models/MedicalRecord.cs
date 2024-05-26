using System;
using System.ComponentModel.DataAnnotations;

namespace kutya_sajat_api.Data.Models
{
    public class MedicalRecord
    {
        public int MedicalRecordId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }

        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}
