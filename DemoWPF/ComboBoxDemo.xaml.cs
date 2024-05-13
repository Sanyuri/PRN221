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
using System.Xml.Linq;

namespace DemoWPF
{
    /// <summary>
    /// Interaction logic for ComboBoxDemo.xaml
    /// </summary>
    public partial class ComboBoxDemo : Window
    {
        public ComboBoxDemo()
        {
            InitializeComponent();
        }
        private void cboColor_SelectionChanged(Object sender, SelectionChangedEventArgs e)
        {
            var stackPanel = (StackPanel)cboColor.SelectedItem;
            var label = stackPanel.Children[1] as Label;
            string color = label.Content.ToString();
            lesg.Content = "Your color is " + color;
        }
    }
}
