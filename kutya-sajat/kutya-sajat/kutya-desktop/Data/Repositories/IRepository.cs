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
        public Task BuildListViewDataGrid();
        public IRepository BuildInstance(DataGrid dataGrid, IDatagridCompatibleViewModel viewModel);
        public Task CommitChanges();
        public Task DeleteSelectedGridItems();
    }
}
