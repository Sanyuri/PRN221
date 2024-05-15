using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DemoLoadDBUsingWPF.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoLoadDBUsingWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Load(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void Load()
        {
            var list = PRN211_1Context.INSTANCE.Students.Include(x => x.Depart).ToList();
            dgvDisplay.ItemsSource = list;
            var cbxDepartContent = PRN211_1Context.INSTANCE.Departments.ToList();
            cbxDepart.ItemsSource = cbxDepartContent;

        }
    }
}