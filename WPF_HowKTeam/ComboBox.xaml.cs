using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WPF_HowKTeam
{
    /// <summary>
    /// Interaction logic for ComboBox.xaml
    /// </summary>
    public partial class ComboBox : Window
    {
        public ComboBox()
        {
            InitializeComponent();
        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            cbItemSource.ItemsSource = new List<string>() { "1","2","3"};
            cbItemSource.DisplayMemberPath = "Name";

            cbItemSource.SelectionChanged += cbItemSource_SelectionChanged;
        }

        private void cbItemSource_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(cbItemSource.SelectedItem.ToString());
        }
    }
}
