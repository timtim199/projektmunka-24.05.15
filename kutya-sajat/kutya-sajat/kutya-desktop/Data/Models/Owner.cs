using System.Collections.Generic;

namespace kutya_desktop.Data.Models
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string IdCardNumber { get; set; }

        public List<Animal> Animals { get; } = new();
    }
}
