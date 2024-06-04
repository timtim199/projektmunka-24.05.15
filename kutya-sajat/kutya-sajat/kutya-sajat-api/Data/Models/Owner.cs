using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace kutya_sajat_api.Data.Models
{
    public class Owner : IModel
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string IdCardNumber { get; set; }

        public List<Animal> Animals { get; } = new();

        public void IncludeAll(DbContext context)
        {
            context.Entry(this).Collection(x => x.Animals).Load();
        }

        public override string ToString()
        {
            return $"{OwnerId}{Name}{IdCardNumber}";
        }
    }
}
