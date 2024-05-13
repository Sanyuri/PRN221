using System.Windows;
using System.Windows.Controls;

namespace DemoWPF
{
    /// <summary>
    /// Interaction logic for Canvas_Panel_Demo.xaml
    /// </summary>
    public partial class CanvasPanelDemo : Window
    {
        public CanvasPanelDemo()
        {
            InitializeComponent();
        }
        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            string CarInfo = $"Car Name : {txtCarName.Text}\n" +
                            $"Color : {txtColor.Text}\nBrand:{txtBrand.Text}";
            MessageBox.Show(CarInfo, "Car Details");
        }
    }
}
