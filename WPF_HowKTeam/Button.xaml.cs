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
    /// Interaction logic for Button.xaml
    /// </summary>
    public partial class Button : Window
    {
        public Button()
        {
            InitializeComponent();

            Button btn = new Button();
            btn.Content = "Free Education";
            grdButton.Children.Add(btn);

            //TextBlock txbl = new TextBlock();
            //txbl.Content = "Share to be better";
            //btn.Content = txbl;

            TextBox textBox = new TextBox();
            textBox.Width = 100;
            textBox.Height = 50;
            btn.Content = textBox;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Clicked");
        }
    }
}
