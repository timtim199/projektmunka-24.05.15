using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutya_desktop.Data.Models
{
    public class SearchDto
    {
        public string Query { get; set; }
        public int Page { get; set; } = 0;
    }
}
