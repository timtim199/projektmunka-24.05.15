using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace kutya_desktop.Controls
{
    public class ButtonControlModel
    {
        public string Content { get; }

        public ICommand Command { get; }

        public ButtonControlModel(string content, ICommand command)
        {
            Content = content;
            Command = command;
        }
    }
}
