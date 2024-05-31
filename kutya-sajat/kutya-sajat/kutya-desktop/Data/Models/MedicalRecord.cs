using System;
using System.ComponentModel.DataAnnotations;

namespace kutya_desktop.Data.Models
{
    public class MedicalRecord
    {
        public int MedicalRecordId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Description { get; set; }

        public int AnimalId { get; set; }
        public Animal Animal { get; set; }

        public MedicalRecord()
        {
            if(CreatedAt == null)
            {
                CreatedAt = DateTime.Now;
            }
        }
    }
}
