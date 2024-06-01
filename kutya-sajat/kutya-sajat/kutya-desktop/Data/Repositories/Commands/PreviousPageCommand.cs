using kutya_desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace kutya_desktop.Data.Repositories.Commands
{
    class PreviousPageCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private IDatagridCompatibleViewModel viewModel;
        public PreviousPageCommand(IDatagridCompatibleViewModel _viewModel)
        {
            viewModel = _viewModel;
        }

        public bool CanExecute(object? parameter)
            => true;

        public void Execute(object? parameter)
        {
            if(viewModel.Page.Value-1 < 0)
            {
                viewModel.Page.Value = 0;
            }
            else
                viewModel.Page.Value -= 1;

        }
    }
}
