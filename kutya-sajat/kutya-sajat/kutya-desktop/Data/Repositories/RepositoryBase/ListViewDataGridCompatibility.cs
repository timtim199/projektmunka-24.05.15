using kutya_desktop.Controls;
using kutya_desktop.Data.Api;
using kutya_desktop.Data.Models;
using kutya_desktop.Data.Repositories.Commands;
using kutya_desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;
using kutya_desktop.Data.Repositories.RepositoryBase.Controls;

namespace kutya_desktop.Data.Repositories.RepositoryBase

{
    internal abstract partial class Repository<T> : IRepository, IDisposable where T : class, IDataModel, new()
    {
        public virtual async Task BuildListViewDataGrid()
        {
            viewModel.ActiveDatasetSub.PropertyChanged += ActiveDatasetSubOnPropertyChanged;
            listView = new(this);
            await listView.BuildGrid();
        }

        private void ActiveDatasetSubOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            Dispose();
        }

        internal class ListViewCompatibility<T> : IDisposable where T : class, IDataModel, new()
        {
            protected List<T> ChangedItems = new();
            protected readonly IApiClient<T> Client = new T().ConstructApiClient<T>(ApplicationWorker.ApiClient);
            protected readonly ObservableCollection<T> Entities = new();
            protected IDatagridCompatibleViewModel viewModel;
            protected DataGrid dataGrid;
            protected Repository<T> parent;
            private bool activeSearch = false;
            private string searchQuery = String.Empty;
            private Timer searchTypeTimer;

            internal async Task BuildGrid()
            {
                BuildDataGridHeaders();
                BuildDataGridControls();
                parent.controlButtons.CollectionChanged += ControlButtonsOnCollectionChanged;
                await LoadDataIntoDataGrid();
            }

            private void ControlButtonsOnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
            {
                BuildDataGridControls();
            }

            public ListViewCompatibility(Repository<T> _parent)
            {
                parent = _parent;
                dataGrid = _parent.dataGrid;
                viewModel = _parent.viewModel;
                viewModel.SearchBox.PropertyChanged += SearchBoxOnPropertyChanged;
            }

            private async void SearchBoxOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
            {
                await Search(viewModel.SearchBox.Value);
            }

            private async Task Search(string text)
            {
                if (String.IsNullOrWhiteSpace(text))
                {
                    activeSearch = false;
                    searchQuery = String.Empty;
                    await RefreshDatagrid();
                }
                else
                {
                    activeSearch = true;
                    searchQuery = text;
                    viewModel.Page.Value = 0;
                    if (searchTypeTimer is not null)
                    {
                        searchTypeTimer.Stop();
                        searchTypeTimer = new Timer(1000);
                        searchTypeTimer.Elapsed += async (sender, args) =>
                        {
                            await RefreshDatagrid();
                        };

                    }
                }
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

                foreach (IControlButton controlButton in parent.controlButtons)
                {
                    viewModel.ButtonControlData.Add(controlButton.GetModel());
                }

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

            public async Task CommitChanges()
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

            internal async Task DeleteSelectedItem()
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

                List<T> entities = await FetchData();
                entities.ForEach(b =>
                {
                    Entities.Add(b);
                });
                dataGrid.Dispatcher.Invoke(() =>
                {
                    dataGrid.ItemsSource = entities;
                });
            }

            private async Task<List<T>> FetchData()
            {
                if (activeSearch)
                {
                    SearchDto dto = new SearchDto();
                    dto.Page = viewModel.Page.Value;
                    dto.Query = searchQuery;
                    return (await Client.SearchAsync(dto)).ToList();
                }
                else
                {
                    return (await Client.GetPageAsync(viewModel.Page.Value)).ToList();
                }
            }

            private async Task RefreshDatagrid()
            {
                await BuildGrid();
            }

            public void Dispose()
            {
                ReleaseSubscriptions();
            }

            private void ReleaseSubscriptions()
            {
                viewModel.Page.PropertyChanged -= PageOnPropertyChanged;
                dataGrid.CellEditEnding -= PushToChangedList;
                viewModel.SearchBox.PropertyChanged -= SearchBoxOnPropertyChanged;
            }
        }

        

        
    }
}
