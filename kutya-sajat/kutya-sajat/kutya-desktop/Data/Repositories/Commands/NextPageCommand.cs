using kutya_desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace kutya_desktop.Data.Repositories.Commands
{
    internal class NextPageCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private IDatagridCompatibleViewModel viewModel;
        public NextPageCommand(IDatagridCompatibleViewModel _viewModel)
        {
            viewModel= _viewModel;
        }

        public bool CanExecute(object? parameter)
            => true;

        public void Execute(object? parameter)
            => viewModel.Page.Value += 1;
    }
}
