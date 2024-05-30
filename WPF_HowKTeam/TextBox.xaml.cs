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
    /// Interaction logic for TextBox.xaml
    /// </summary>
    public partial class TextBox : Window
    {
        public TextBox()
        {
            InitializeComponent();
        }

        private void btnValue_Click(object sender, RoutedEventArgs e)
        {
            txtblValue.Text = txtValue.Text;
        }
        int DoubleValue(int value)
        {
            return value * 2;
        }

        private void txtValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            int value = 0;
            if(int.TryParse(txtValue.Text, out value))
            {
                txtblValue.Text = DoubleValue(value).ToString();
            }
            else
            {
                txtblValue.Text = "Wrong type";
            }
        }
    }
}
