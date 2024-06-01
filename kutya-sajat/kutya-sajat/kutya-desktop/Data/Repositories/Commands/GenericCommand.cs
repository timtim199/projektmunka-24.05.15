using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace kutya_desktop.Data.Repositories.Commands
{
    class GenericCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        Action onExecute;
        public GenericCommand(Action _onExecute)
        {
            onExecute = _onExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            onExecute?.Invoke();
        }
    }
}
