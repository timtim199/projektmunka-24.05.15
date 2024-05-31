using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutya_desktop.Data.Models
{
    internal class ResponseDto<T>
    {
        public bool Success { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
