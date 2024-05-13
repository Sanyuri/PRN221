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
    /// Interaction logic for DataGridDemo.xaml
    /// </summary>
    public partial class DataGridDemo : Window
    {
        public DataGridDemo()
        {
            InitializeComponent();

            Loaded += DemoDataGrid_Loaded;
        }

        private void DemoDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            //Create a Car List
            List<dynamic> cars = new List<dynamic> {
                new {CarName = "A6", Color="white", Brand="Audi" },
                new {CarName = "Lexus S78", Color="Black", Brand="Toyota" },
                new {CarNane = "Ford Ranger Raptor", Color="white", Brand="Ford" }
               };
            //Binding on DataGrid
            dgCarList.ItemsSource = cars;
        }
    }
}
