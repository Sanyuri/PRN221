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
    /// Interaction logic for ListBox.xaml
    /// </summary>
    public partial class ListBox : Window
    {
        List<string> ListData;
        public ListBox()
        {
            InitializeComponent();
            ListData = new List<string>();
            ListData.AddRange(new string[] {"1","2","3"});

            cbCombo.ItemsSource = ListData;
            lsbList.ItemsSource = ListData;
        }
    }
}
