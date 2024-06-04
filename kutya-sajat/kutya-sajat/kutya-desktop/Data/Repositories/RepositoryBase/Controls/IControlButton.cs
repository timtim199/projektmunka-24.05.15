using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using kutya_desktop.Controls;
using kutya_desktop.ViewModels;

namespace kutya_desktop.Data.Repositories.RepositoryBase.Controls
{
    internal interface IControlButton
    {
        public IDatagridCompatibleViewModel ViewModel { get; set; }
        public IRepository Repository { get; set; }
        public ButtonControlModel GetModel();
    }
}
