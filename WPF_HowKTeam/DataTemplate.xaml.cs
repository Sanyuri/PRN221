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
    /// Interaction logic for DataTemplate.xaml
    /// </summary>
    public partial class DataTemplate : Window
    {
        public DataTemplate()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str1 = "www.HowKTeam.com";
            string str2 = "asdasds";

            btn1.DataContext = str1;
            btn2.DataContext = str2;
        }
    }
}
