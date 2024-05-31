using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace kutya_sajat_api.Data.Models
{
    public class Breed : IModel
    {
        public int BreedId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public virtual List<Animal> Animals { get; set; }

        public void IncludeAll(DbContext context)
        {
            context.Entry(this).Collection(x => x.Animals).Load();
        }
    }
}
