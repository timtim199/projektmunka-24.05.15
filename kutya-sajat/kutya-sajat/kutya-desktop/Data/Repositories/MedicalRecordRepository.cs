using kutya_desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using kutya_desktop.Data.Models;
using kutya_desktop.Data.Repositories.RepositoryBase;
using kutya_desktop.Data.Repositories.RepositoryBase.Controls;

namespace kutya_desktop.Data.Repositories
{
    internal class MedicalRecordRepository : Repository<MedicalRecord>
    {
        public override Dataset Dataset => Dataset.MedicalRecords;

        public override IRepository BuildInstance(DataGrid dataGrid, IDatagridCompatibleViewModel viewModel)
        {
            return new MedicalRecordRepository()
            {
                viewModel = viewModel,
                dataGrid = dataGrid
            };
        }

        private void InitListViewButtons()
        {
            EnableButton<NextPageButton>();
            EnableButton<PreviousPageButton>();
            EnableButton<DeleteButton>();
        }

        public override async Task BuildListViewDataGrid()
        {
            await base.BuildListViewDataGrid();
            InitListViewButtons();
        }
    }
}
