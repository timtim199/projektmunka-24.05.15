using kutya_desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using kutya_desktop.Data.Api;

namespace kutya_desktop.Data.Models
{
    public interface IDataModel
    {
        public int? GetIdentitifier();
        public void BuildDataGridHeaders(DataGrid dataGrid);
        public void BuildDataGridControls(IDatagridCompatibleViewModel viewModel);
        public IApiClient<T> ConstructApiClient<T>(ApiClient baseClient) where T : IDataModel;
    }
}
