using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using kutya_desktop.Controls;
using kutya_desktop.Data.Api;
using kutya_desktop.Data.Models;
using kutya_desktop.Data.Repositories.Commands;
using kutya_desktop.Data.Repositories.RepositoryBase.Controls;
using kutya_desktop.ViewModels;

namespace kutya_desktop.Data.Repositories.RepositoryBase
{
    internal abstract partial class Repository<T>  : IRepository, IDisposable where T : class, IDataModel, new()
    {
        public abstract Dataset Dataset { get; }

        protected List<T> ChangedItems = new();
        protected readonly IApiClient<T> Client = new T().ConstructApiClient<T>(ApplicationWorker.ApiClient);
        protected readonly ObservableCollection<T> Entities = new();
        protected IDatagridCompatibleViewModel viewModel;
        protected DataGrid dataGrid;
        protected Repository<T>.ListViewCompatibility<T>? listView;
        protected readonly ObservableCollection<IControlButton> controlButtons = new();



        public abstract IRepository BuildInstance(DataGrid dataGrid, IDatagridCompatibleViewModel viewModel);
        public async Task CommitChanges()
        {
            if (listView != null)
            {
                await listView.CommitChanges();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task DeleteSelectedGridItems()
        {
            await listView.DeleteSelectedItem();
        }

        protected void EnableButton<T>() where T: class, IControlButton, new()
        {
            T button = new T();
            button.Repository = this;
            button.ViewModel = viewModel;

            controlButtons.Add(button);
        }

        public void Dispose()
        {
            viewModel.ActiveDatasetSub.PropertyChanged -= ActiveDatasetSubOnPropertyChanged;
            listView?.Dispose();
        }


    }
}
