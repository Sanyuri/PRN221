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
    /// Interaction logic for RadioButtonDemo.xaml
    /// </summary>
    public partial class RadioButtonDemo : Window
    {
        public RadioButtonDemo()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;

            if (checkBox != null && checkBox.IsChecked == true)
            {
                if (checkBox == checkBox1)
                {
                    checkBox2.IsChecked = false;
                    checkBox3.IsChecked = false;
                }
                else if (checkBox == checkBox2)
                {
                    checkBox1.IsChecked = false;
                    checkBox3.IsChecked = false;
                }
                else if (checkBox == checkBox3)
                {
                    checkBox1.IsChecked = false;
                    checkBox2.IsChecked = false;
                }
            }
        }
    }
}
