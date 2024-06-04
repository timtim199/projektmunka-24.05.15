using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kutya_desktop.Controls;
using kutya_desktop.Data;

namespace kutya_desktop.ViewModels
{
    internal class DetailedViewModel : IDatagridCompatibleViewModel
    {
        public Prop<int> Page { get; } = new Prop<int>();

        public ObservableCollection<ButtonControlModel> ButtonControlData { get; } =
            new ObservableCollection<ButtonControlModel>();
        public Dataset ActiveDataset { get; set; }
        public Prop<Dataset> ActiveDatasetSub { get; } = new Prop<Dataset>();
        public Prop<string> SearchBox { get; } = new Prop<string>();
    }
}
