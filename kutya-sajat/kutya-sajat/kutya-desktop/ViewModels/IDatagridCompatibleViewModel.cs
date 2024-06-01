﻿using kutya_desktop.Controls;
using kutya_desktop.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutya_desktop.ViewModels
{
    interface IDatagridCompatibleViewModel
    {
        public Prop<int> Page { get; }
        public ObservableCollection<ButtonControlModel> ButtonControlData { get; }
        public Dataset ActiveDataset { get; set; }
    }
}
