using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for SOrting.xaml
    /// </summary>
    public partial class SOrting : Window
    {
        bool isSort;
        public SOrting()
        {
            InitializeComponent();

            isSort = false;
            List<User> items = new List<User>();
            items.Add(new User { Name = "User 1", Age = 18 });
            items.Add(new User { Name = "User 2", Age = 19 });
            items.Add(new User { Name = "User 3", Age = 17 });
            lstUser.ItemsSource = items;

        

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lstUser.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Age", ListSortDirection.Descending));
        }


        public class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader header= sender as GridViewColumnHeader;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lstUser.ItemsSource);
            if (isSort)
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription(header.Content.ToString(), ListSortDirection.Ascending));
              
            }
            else
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription(header.Content.ToString(), ListSortDirection.Descending));
            }
            isSort = !isSort;
        }
    }
}
