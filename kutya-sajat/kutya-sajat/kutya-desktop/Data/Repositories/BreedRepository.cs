using kutya_desktop.Data.Api;
using kutya_desktop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace kutya_desktop.Data.Repositories
{
    internal class BreedRepository : IRepository
    {
        public Dataset Dataset => Dataset.Breeds;
        
        private readonly BreedApiClient client;
        public BreedRepository()
        {
            client = new BreedApiClient(ApplicationWorker.ApiClient);
        }


        public async Task BuildDatagrid(DataGrid dataGrid, int page = 0)
        {
            BuildDatagridHeaders(dataGrid);
            await BuildDataForGrid(dataGrid, page);
        }

        private void BuildDatagridHeaders(DataGrid dataGrid)
        {
            dataGrid.Columns.Clear();

            DataGridTextColumn idColumn = new DataGridTextColumn();
            idColumn.Header = "Azonosító";
            idColumn.Binding = new Binding("BreedId");
            dataGrid.Columns.Add(idColumn);

            DataGridTextColumn nameColumn = new DataGridTextColumn();
            nameColumn.Header = "Név";
            nameColumn.Binding = new Binding("Name");
            dataGrid.Columns.Add(nameColumn);

            DataGridTextColumn descriptionColumn = new DataGridTextColumn();
            descriptionColumn.Header = "Leírás";
            descriptionColumn.Binding = new Binding("Description");
            dataGrid.Columns.Add(descriptionColumn);
        }

        private async Task BuildDataForGrid(DataGrid dataGrid, int page)
        {
            List<Breed> breeds = (await client.GetBreedsByPageAsync(page)).ToList();
            breeds.ForEach(b =>
            {
                dataGrid.Dispatcher.Invoke(() =>
                {
                    InsertEntryForGrid(dataGrid, b);
                });
            });
        }

        private void InsertEntryForGrid(DataGrid grid, Breed entry)
        {
            grid.Items.Add(entry);
        }
    }
}
