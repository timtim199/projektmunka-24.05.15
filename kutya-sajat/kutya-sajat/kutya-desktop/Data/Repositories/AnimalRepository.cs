using kutya_desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using kutya_desktop.Data.Models;

namespace kutya_desktop.Data.Repositories
{
    internal class AnimalRepository : Repository<Animal>
    {
        public override Dataset Dataset { get => Dataset.Animals; }
        public override IRepository BuildInstance(DataGrid dataGrid, IDatagridCompatibleViewModel viewModel)
        {
            return new AnimalRepository()
            {
                viewModel = viewModel,
                dataGrid = dataGrid
            };
        }

        protected override void BuildDataGridControls()
        {
            base.BuildDataGridControls();

        }
    }
}
