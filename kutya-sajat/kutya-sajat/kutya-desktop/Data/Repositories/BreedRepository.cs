using kutya_desktop.Controls;
using kutya_desktop.Data.Api;
using kutya_desktop.Data.Models;
using kutya_desktop.Data.Repositories.Commands;
using kutya_desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace kutya_desktop.Data.Repositories
{
    internal class BreedRepository : Repository<Breed>
    {
        public override Dataset Dataset => Dataset.Breeds;

        public override IRepository BuildInstance(DataGrid dataGrid, IDatagridCompatibleViewModel viewModel)
        {
            return new BreedRepository()
            {
                viewModel = viewModel,
                dataGrid = dataGrid
            };
        }
    }

    
}
