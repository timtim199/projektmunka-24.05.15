using kutya_desktop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutya_desktop.Data.Repositories.RepositoryBase
{
    internal abstract partial class Repository<T> : IRepository, IDisposable where T : class, IDataModel, new()
    {
        internal class DetailedViewCompatibility<T> : IDisposable where T : class, IDataModel, new()
        {
            public void Dispose()
            {
                ReleaseSubscriptions();
            }

            private void ReleaseSubscriptions()
            {

            }
        }
    }
}
