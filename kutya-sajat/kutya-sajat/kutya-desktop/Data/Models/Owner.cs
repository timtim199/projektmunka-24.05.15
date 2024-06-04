using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Data;
using kutya_desktop.Data.Api;
using kutya_desktop.ViewModels;

namespace kutya_desktop.Data.Models
{
    public class Owner : IDataModel
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string IdCardNumber { get; set; }

        public List<Animal> Animals { get; } = new();

        public int? GetIdentitifier()
            => OwnerId;

        public void BuildDataGridHeaders(DataGrid dataGrid)
        {
            DataGridTextColumn idColumn = new DataGridTextColumn();
            idColumn.Header = "Azonosító";
            idColumn.Binding = new Binding("OwnerId");
            dataGrid.Columns.Add(idColumn);

            DataGridTextColumn nameColumn = new DataGridTextColumn();
            nameColumn.Header = "Név";
            nameColumn.Binding = new Binding("Name");
            dataGrid.Columns.Add(nameColumn);

            DataGridTextColumn ownerIdCard = new DataGridTextColumn();
            ownerIdCard.Header = "Szig. száma";
            ownerIdCard.Binding = new Binding("IdCardNumber");
            dataGrid.Columns.Add(ownerIdCard);
        }

        public void BuildDataGridControls(IDatagridCompatibleViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public IApiClient<T> ConstructApiClient<T>(ApiClient baseClient) where T : IDataModel
        {
            return (new OwnerApiClient(baseClient) as IApiClient<T>);
        }
    }
}
