using kutya_desktop.Controls;
using kutya_desktop.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutya_desktop.ViewModels
{
    public class MainViewModel : IDatagridCompatibleViewModel
    {
        public ObservableCollection<ButtonControlModel> ButtonControlData { get; } = new ObservableCollection<ButtonControlModel>();
        public Prop<int> Page { get; set; } = new Prop<int>();
        public Dataset ActiveDataset { get; set; }

        public MainViewModel()
        {
            Page.Value = 0;
        }
    }
}
