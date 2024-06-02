using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using kutya_desktop.Controls;
using kutya_desktop.Data.Api;
using kutya_desktop.Data.Models;
using kutya_desktop.Data.Repositories.Commands;
using kutya_desktop.ViewModels;

namespace kutya_desktop.Data.Repositories
{
    internal abstract partial class Repository<T>  : IRepository where T : class, IDataModel, new()
    {

        public abstract Dataset Dataset { get; }

        protected List<T> ChangedItems = new();
        protected readonly IApiClient<T> Client = new T().ConstructApiClient<T>(ApplicationWorker.ApiClient);
        protected readonly ObservableCollection<T> Entities = new();
        protected IDatagridCompatibleViewModel viewModel;
        protected DataGrid dataGrid;

        public abstract IRepository BuildInstance(DataGrid dataGrid, IDatagridCompatibleViewModel viewModel);

        public async Task BuildDatagrid()
        {
            BuildDataGridHeaders();
            BuildDataGridControls();
            await LoadDataIntoDataGrid();
        }

        protected virtual void BuildDataGridHeaders()
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.Columns.Clear();   
            new T().BuildDataGridHeaders(dataGrid);
        }

        protected virtual void BuildDataGridControls()
        {
            viewModel.ButtonControlData.Clear();
            viewModel.ButtonControlData.Add(new ButtonControlModel("Következő lap", new NextPageCommand(viewModel)));
            viewModel.ButtonControlData.Add(new ButtonControlModel("Előző lap", new PreviousPageCommand(viewModel)));
            viewModel.ButtonControlData.Add(new ButtonControlModel("Mentés", new GenericCommand(async () =>
            {
                await CommitChanges();
            })));
            viewModel.ButtonControlData.Add(new ButtonControlModel("Törlés", new GenericCommand(async () =>
            {
                await DeleteSelectedItem();
            })));

            viewModel.Page.PropertyChanged -= PageOnPropertyChanged;
            viewModel.Page.PropertyChanged += PageOnPropertyChanged;


            InitEditEventHandlers();
        }


        private async void PageOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            await RefreshDatagrid();
        }

        private void InitEditEventHandlers()
        {
            dataGrid.CellEditEnding -= PushToChangedList;
            dataGrid.CellEditEnding += PushToChangedList;
        }

        private void PushToChangedList(object? sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.Row.Item is not T item) return;
            if (!ChangedItems.Contains(item))
            {
                ChangedItems.Add(item);
            }
        }

        private async Task CommitChanges()
        {
            dataGrid.CommitEdit();
            foreach (var entity in ChangedItems)
            {
                await CommitChange(entity);
            }
            ChangedItems.Clear();
            await RefreshDatagrid();
        }

        private async Task CommitChange(T entity)
        {
            if (entity.GetIdentitifier() == null)
            {
                await Client.CreateAsync(entity);
            }
            else
            {
                await Client.UpdateAsync(entity.GetIdentitifier().Value, entity);
            }
        }

        private async Task DeleteSelectedItem()
        {
            var items = dataGrid.SelectedItems;
            foreach (T item in items)
            {
                if (item.GetIdentitifier().HasValue)
                {
                    await Client.DeleteAsync(item.GetIdentitifier().Value);
                }
            }
            await RefreshDatagrid();
        }

        private async Task LoadDataIntoDataGrid()
        {
            Entities.Clear();

            List<T> entities = (await Client.GetPageAsync(viewModel.Page.Value)).ToList();
            entities.ForEach(b =>
            {
                Entities.Add(b);
            });
            dataGrid.Dispatcher.Invoke(() =>
            {
                dataGrid.ItemsSource = entities;
            });
        }

        private async Task RefreshDatagrid()
        {
            await BuildDatagrid();
        }
    }
}
