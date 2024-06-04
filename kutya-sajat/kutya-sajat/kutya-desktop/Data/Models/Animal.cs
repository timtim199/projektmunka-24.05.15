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
        public Breed Breed { get; set; }

        public int OwnerId { get; set; }
        public Owner Owner { get; set; }

        [JsonIgnore]
        public List<MedicalRecord> MedicalRecords { get; set; }

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
            nameColumn.Binding = new Binding("Name");
            dataGrid.Columns.Add(nameColumn);

            DataGridTextColumn descriptionColumn = new DataGridTextColumn();
            descriptionColumn.Header = "Születési dátum";
            descriptionColumn.Binding = new Binding("DateOfBirth");
            dataGrid.Columns.Add(descriptionColumn);

            DataGridTextColumn breedColumn = new DataGridTextColumn();
            breedColumn.Header = "Fajta";
            breedColumn.Binding = new Binding("Breed.Name");
            dataGrid.Columns.Add(breedColumn);

            DataGridTextColumn ownerNameColumn = new DataGridTextColumn();
            ownerNameColumn.Header = "Gazda neve";
            ownerNameColumn.Binding = new Binding("Owner.Name");
            dataGrid.Columns.Add(ownerNameColumn);

            DataGridTextColumn ownerIdCard = new DataGridTextColumn();
            ownerIdCard.Header = "Gazda Szig. száma";
            ownerIdCard.Binding = new Binding("Owner.IdCardNumber");
            dataGrid.Columns.Add(ownerIdCard);
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
