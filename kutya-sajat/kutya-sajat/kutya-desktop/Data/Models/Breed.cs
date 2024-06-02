using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows.Controls;
using System.Windows.Data;
using kutya_desktop.Controls;
using kutya_desktop.Data.Api;
using kutya_desktop.Data.Repositories.Commands;
using kutya_desktop.ViewModels;

namespace kutya_desktop.Data.Models
{
    public class Breed : IDataModel
    {
        public int? BreedId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual List<Animal>? Animals { get; set; }

        public int? GetIdentitifier()
            => BreedId;

        public void BuildDataGridHeaders(DataGrid dataGrid)
        {
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

        public void BuildDataGridControls(IDatagridCompatibleViewModel viewModel)
        {

        }

        public IApiClient<T> ConstructApiClient<T>(ApiClient baseClient) where T : IDataModel
        {
            return (new BreedApiClient(baseClient) as IApiClient<T>);
        }
    }
}
