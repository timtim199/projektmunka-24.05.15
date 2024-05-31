using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace kutya_desktop.Data.Models
{
    public class Breed
    {
        public int? BreedId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual List<Animal>? Animals { get; set; }
    }
}
