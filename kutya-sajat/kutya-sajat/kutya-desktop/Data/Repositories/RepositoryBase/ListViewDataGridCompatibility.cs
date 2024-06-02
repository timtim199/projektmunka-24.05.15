using kutya_desktop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutya_desktop.Data.Repositories
{
    internal abstract partial class Repository<T> : IRepository where T : class, IDataModel, new()
    {
    }
}
