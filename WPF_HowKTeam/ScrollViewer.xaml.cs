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
    /// Interaction logic for ScrollViewer.xaml
    /// </summary>
    public partial class ScrollViewer : Window
    {
        public ScrollViewer()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ////get scroll bar offset value
            //MessageBox.Show(scrViewer.VerticalOffset.ToString());

            ////get viewport height
            //MessageBox.Show(scrViewer.ViewportHeight.ToString());

            ////scroll to end
            //scrViewer.ScrollToEnd();

            ////maximum scroll offset
            //MessageBox.Show(scrViewer.ScrollableHeight.ToString());
        }
    }
}
