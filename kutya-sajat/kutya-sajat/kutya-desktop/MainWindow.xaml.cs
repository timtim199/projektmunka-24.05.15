using kutya_desktop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kutya_desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitListBox();
        }

        private void InitListBox()
        {
            datasetsListBox.Items.Clear();
            foreach(var value in Enum.GetValues<Dataset>())
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = value.GetAttributeOfType<DescriptionAttribute>().Description;
                item.Tag = value;
                datasetsListBox.Items.Add(item);
            }
        }

        private async void datasetsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(mainDatagrid != null)
            {
                Dataset dataset = (Dataset)(datasetsListBox.SelectedItem as ListBoxItem).Tag;
                await ApplicationWorker.BuildDatagrid(mainDatagrid, dataset);
            }
            
        }

        private void mainDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
