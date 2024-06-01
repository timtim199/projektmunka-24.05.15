using kutya_desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace kutya_desktop.Data.Repositories
{
    internal interface IRepository
    {
        public Dataset Dataset { get; }
        public Task BuildDatagrid(DataGrid dataGrid, int page = 0, IDatagridCompatibleViewModel? viewModel = null);
    }
}
