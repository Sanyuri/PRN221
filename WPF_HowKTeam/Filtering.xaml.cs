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
    /// Interaction logic for Filtering.xaml
    /// </summary>
    public partial class Filtering : Window
    {
        public Filtering()
        {
            InitializeComponent();

            List<User> items = new List<User>();
            items.Add(new User { Name = "User 1", Age = 18, Sex = SexType.Male });
            items.Add(new User { Name = "User 2", Age = 19, Sex = SexType.Felame });
            items.Add(new User { Name = "User 3", Age = 17, Sex = SexType.Male });
            lstUser.ItemsSource = items;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lstUser.ItemsSource);
            view.Filter = UserFilter;
        }
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as User).Name.IndexOf(txtFilter.Text,StringComparison.OrdinalIgnoreCase) >= 0);
        }
        public enum SexType { Male, Felame };

        public class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public SexType Sex { get; set; }
        }
        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lstUser.ItemsSource).Refresh();
        }
    }
}
