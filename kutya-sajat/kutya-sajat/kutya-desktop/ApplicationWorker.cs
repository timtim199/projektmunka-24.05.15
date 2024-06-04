using kutya_desktop.Data;
using kutya_desktop.Data.Api;
using kutya_desktop.Data.Repositories;
using kutya_desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using kutya_desktop.Data.Models;

namespace kutya_desktop
{
    internal static class ApplicationWorker
    {
        public static readonly IRepository[] repositories;
        public static ApiClient ApiClient => new ApiClient("http://localhost:5000");
        static ApplicationWorker()
        {
            repositories = new IRepository[] { new BreedRepository(), new AnimalRepository(), new OwnerRepository(), new MedicalRecordRepository() };
        }
        public static async Task BuildDatagrid(DataGrid dataGrid, IDatagridCompatibleViewModel? viewModel = null, int page = 0)
        {

            try
            {
                await GetRepository(viewModel.ActiveDataset).BuildInstance(dataGrid, viewModel).BuildListViewDataGrid();
            }
            catch (Exception ex)
            {
                dataGrid.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show($"Sikertelen betöltés. {ex.Message}");
                });
            }


        }

        public static IRepository GetRepository(Dataset dataset)
        {
            foreach (IRepository repository in repositories)
            {
                if(repository.Dataset == dataset)
                {
                    return repository;
                }
            }
            throw new Exception();
        }
    }
}
