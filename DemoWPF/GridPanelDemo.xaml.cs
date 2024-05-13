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
    /// Interaction logic for GridPanelDemo.xaml
    /// </summary>
    public partial class GridPanelDemo : Window
    {
        public GridPanelDemo()
        {
            InitializeComponent();
        }
        //private void btnDisplay_Click(object sender, RoutedEventArgs e)
        //{
        //    string UserInfo = $"Name : {grdName.Text}\n" +
        //                    $"Email : {grdEmail.Text}\nComment: {grdComment.Text}";
        //    MessageBox.Show(UserInfo, "Car Details");
        //}

        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            string UserInfo = $"Name : {grdName.Text}\n" +
                            $"Email : {grdEmail.Text}\nComment: {grdComment.Text}";
            grdInfo.Text = UserInfo;
        }
    }
}
