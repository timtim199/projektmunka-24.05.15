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
    internal class BreedRepository : IRepository
    {
        public Dataset Dataset => Dataset.Breeds;
        
        private readonly ObservableCollection<Breed> Breeds;
        private readonly BreedApiClient client;
        private readonly List<Breed> editedElementList;
        public BreedRepository()
        {
            Breeds = new ObservableCollection<Breed>();
            editedElementList = new List<Breed>();
            client = new BreedApiClient(ApplicationWorker.ApiClient);
        }


        public async Task BuildDatagrid(DataGrid dataGrid, int page = 0, IDatagridCompatibleViewModel? viewModel = null)
        {
            BuildDatagridHeaders(dataGrid);
            await BuildDataForGrid(dataGrid, page);
            if(viewModel != null)
            {
                BuildGridControls(dataGrid, viewModel);
            }
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

        private void BuildGridControls(DataGrid dataGrid, IDatagridCompatibleViewModel viewModel)
        {
            viewModel.ButtonControlData.Clear();
            viewModel.ButtonControlData.Add(new ButtonControlModel("Következő lap", new NextPageCommand(viewModel)));
            viewModel.ButtonControlData.Add(new ButtonControlModel("Előző lap", new PreviousPageCommand(viewModel)));
            viewModel.ButtonControlData.Add(new ButtonControlModel("Mentés", new GenericCommand(async () =>
            {
                await CommitChanges(dataGrid, viewModel);
            })));

            viewModel.Page.PropertyChanged += async (object? sender, System.ComponentModel.PropertyChangedEventArgs e) =>
            {
                await Page_PropertyChanged(viewModel, dataGrid);
            };

            dataGrid.BeginningEdit += DataGrid_BeginningEdit;
            dataGrid.CellEditEnding += DataGrid_CellEditEnding;
        }

        private void DataGrid_CellEditEnding(object? sender, DataGridCellEditEndingEventArgs e)
        {
            Breed item = (Breed)e.Row.Item;
            PushIntoEditedList(item);
        }

        private async Task CommitChanges(DataGrid dataGrid, IDatagridCompatibleViewModel viewModel)
        {
            dataGrid.CommitEdit();
            foreach(Breed breed in editedElementList)
            {
                await CommitChange(breed);
            }
            await BuildDatagrid(dataGrid, page: viewModel.Page.Value, viewModel);
        }

        private async Task CommitChange(Breed breed)
        {
            if(breed.BreedId == null)
            {
                await client.CreateBreedAsync(breed);
            }    
            else
            {
                await client.UpdateBreedAsync(breed.BreedId.Value, breed);
            }
        }

        private void DataGrid_BeginningEdit(object? sender, DataGridBeginningEditEventArgs e)
        {
            MessageBox.Show("begin edit");
        }

        private async Task Page_PropertyChanged(IDatagridCompatibleViewModel viewModel, DataGrid dataGrid)
        {
            if(viewModel.ActiveDataset == Dataset)
            {
                await BuildDataForGrid(dataGrid, viewModel.Page.Value);
            }
        }

        private async Task BuildDataForGrid(DataGrid dataGrid, int page)
        {
            dataGrid.Dispatcher.Invoke(() =>
            {
                Breeds.Clear();
            });
            List<Breed> breeds = (await client.GetBreedsByPageAsync(page)).ToList();
            breeds.ForEach(b =>
            {
                InsertEntryForGrid(dataGrid, b);
            });
            dataGrid.Dispatcher.Invoke(() =>
            {
                dataGrid.ItemsSource = breeds;
            });
        }

        private void PushIntoEditedList(Breed breed)
        {
            if(!editedElementList.Contains(breed))
            {
                editedElementList.Add(breed);
            }
        }

        private void InsertEntryForGrid(DataGrid grid, Breed entry)
        {
            Breeds.Add(entry);
        }
    }

    
}
