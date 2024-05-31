using kutya_desktop.Data;
using kutya_desktop.Data.Api;
using kutya_desktop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace kutya_desktop
{
    internal static class ApplicationWorker
    {
        public static readonly IRepository[] repositories;
        public static ApiClient ApiClient => new ApiClient("http://localhost:5000");
        static ApplicationWorker()
        {
            repositories = new IRepository[1] { new BreedRepository() };
        }
        public static async Task BuildDatagrid(DataGrid dataGrid, Dataset dataset, int page = 0)
        {

            await GetRepository(dataset).BuildDatagrid(dataGrid, page);
            
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
