using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Windows.Controls;
using System.Windows.Data;
using kutya_desktop.Data.Api;
using kutya_desktop.ViewModels;

namespace kutya_desktop.Data.Models
{
    public class Animal : IDataModel
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int BreedId { get; set; }
        public virtual Breed Breed { get; set; }

        public int OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        [JsonIgnore]
        public virtual List<MedicalRecord> MedicalRecords { get; set; }

        public int? GetIdentitifier()
            => AnimalId;

        public void BuildDataGridHeaders(DataGrid dataGrid)
        {
            DataGridTextColumn idColumn = new DataGridTextColumn();
            idColumn.Header = "Azonosító";
            idColumn.Binding = new Binding("AnimalId");
            dataGrid.Columns.Add(idColumn);

            DataGridTextColumn nameColumn = new DataGridTextColumn();
            nameColumn.Header = "Név";
            nameColumn.Binding = new Binding("Owner.Name");
            dataGrid.Columns.Add(nameColumn);

            DataGridTextColumn descriptionColumn = new DataGridTextColumn();
            descriptionColumn.Header = "Születési dátum";
            descriptionColumn.Binding = new Binding("DateOfBirth");
            dataGrid.Columns.Add(descriptionColumn);
        }

        public void BuildDataGridControls(IDatagridCompatibleViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public IApiClient<T> ConstructApiClient<T>(ApiClient baseClient) where T : IDataModel
        {
            return (new AnimalApiClient(baseClient) as IApiClient<T>);
        }
    }
}
