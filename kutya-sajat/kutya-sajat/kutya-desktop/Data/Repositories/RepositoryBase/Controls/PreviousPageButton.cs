using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kutya_desktop.Controls;
using kutya_desktop.Data.Repositories.Commands;
using kutya_desktop.ViewModels;

namespace kutya_desktop.Data.Repositories.RepositoryBase.Controls
{
    internal class PreviousPageButton : IControlButton
    {
        public IDatagridCompatibleViewModel ViewModel { get; set; }
        public IRepository Repository { get; set; }

        public ButtonControlModel GetModel()
        {
            return new ButtonControlModel("Előző lap", new PreviousPageCommand(ViewModel));
        }
    }
}
