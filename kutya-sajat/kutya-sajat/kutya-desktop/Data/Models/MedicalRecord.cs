using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Controls;
using System.Windows.Data;
using kutya_desktop.Data.Api;
using kutya_desktop.ViewModels;

namespace kutya_desktop.Data.Models
{
    public class MedicalRecord : IDataModel
    {
        public int MedicalRecordId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Description { get; set; }

        public int AnimalId { get; set; }
        public Animal Animal { get; set; }

        public MedicalRecord()
        {
            if(CreatedAt == null)
            {
                CreatedAt = DateTime.Now;
            }
        }

        public int? GetIdentitifier()
            => MedicalRecordId;

        public void BuildDataGridHeaders(DataGrid dataGrid)
        {
            DataGridTextColumn idColumn = new DataGridTextColumn();
            idColumn.Header = "Azonosító";
            idColumn.Binding = new Binding("MedicalRecordId");
            dataGrid.Columns.Add(idColumn);

            DataGridTextColumn ownerIdCard = new DataGridTextColumn();
            ownerIdCard.Header = "Állat neve";
            ownerIdCard.Binding = new Binding("Animal.Name");
            dataGrid.Columns.Add(ownerIdCard);

            DataGridTextColumn nameColumn = new DataGridTextColumn();
            nameColumn.Header = "Információ";
            nameColumn.Binding = new Binding("Description");
            dataGrid.Columns.Add(nameColumn);

            DataGridTextColumn descriptionColumn = new DataGridTextColumn();
            descriptionColumn.Header = "Nyilvántartásba véve";
            descriptionColumn.Binding = new Binding("CreatedAt");
            dataGrid.Columns.Add(descriptionColumn);

            
        }

        public void BuildDataGridControls(IDatagridCompatibleViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public IApiClient<T> ConstructApiClient<T>(ApiClient baseClient) where T : IDataModel
        {
            return (new MedicalRecordApiClient(baseClient) as IApiClient<T>);
        }
    }
}
