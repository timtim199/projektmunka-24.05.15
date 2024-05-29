using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace kutya_sajat_api.Data.Models
{
    public interface IModel
    {
        public void IncludeAll(DbContext context);
    }
}
