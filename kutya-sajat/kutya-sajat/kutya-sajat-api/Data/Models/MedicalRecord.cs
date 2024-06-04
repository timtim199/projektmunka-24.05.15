using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace kutya_sajat_api.Data.Models
{
    public class MedicalRecord : IModel
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

        public void IncludeAll(DbContext context)
        {
            context.Entry(this).Reference(x => x.Animal).Load();
        }

        public override string ToString()
        {
            return $"{MedicalRecordId}{CreatedAt}{Description}{Animal.Name}";
        }
    }
}
