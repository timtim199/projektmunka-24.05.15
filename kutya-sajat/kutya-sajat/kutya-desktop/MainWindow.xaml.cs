using kutya_desktop.Controls;
using kutya_desktop.Data;
using kutya_desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private bool _windowFrozen = false;
        private int page = 0;

        public MainWindow()
        {
            InitializeComponent();
            InitUiControl();
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

        private void InitUiControl()
        {
            LayoutRoot.PreviewKeyDown += LayoutRoot_PreviewKeyDown;
            LayoutRoot.PreviewMouseDown += LayoutRoot_PreviewMouseDown;
        }

        private async void datasetsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(mainDatagrid != null)
            {
                page = 0;
                await RebuildDatagrid();
            }
        }

        private async Task RebuildDatagrid()
        {
            DisableControls();
            MainViewModel mainViewModel = (MainViewModel)this.DataContext;

            Dataset dataset = (Dataset)(datasetsListBox.SelectedItem as ListBoxItem).Tag;

            mainViewModel.ActiveDataset = dataset;

            await ApplicationWorker.BuildDatagrid(mainDatagrid, mainViewModel);

            EnableControls();
        }

        private void mainDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void DisableControls()
            => _windowFrozen = true;

        private void EnableControls()
            => _windowFrozen = false;

        private void LayoutRoot_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = _windowFrozen;
        }

        private void LayoutRoot_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = _windowFrozen;
        }
    }
}
