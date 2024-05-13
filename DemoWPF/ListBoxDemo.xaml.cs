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

namespace DemoWPF
{
    /// <summary>
    /// Interaction logic for ListBoxDemo.xaml
    /// </summary>
    public partial class ListBoxDemo : Window
    {
        public ListBoxDemo()
        {
            InitializeComponent();
        }
        private void cmd_CheckAllItems(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (CheckBox item in lst.Items)
            {
                if (item.IsChecked == true)
                {
                    sb.Append(item.Content + " is checked.");
                    sb.Append("\r\n");
                }
            }
            txtSelection.Text = sb.ToString();
        }
    }
}
