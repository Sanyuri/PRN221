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
    /// Interaction logic for GridView.xaml
    /// </summary>
    public partial class GridView : Window
    {
        public GridView()
        {
            InitializeComponent();

            List<User> items = new List<User>();
            items.Add(new User {Name = "User 1", Age= 18, Mail="1@gmail.com" });
            items.Add(new User { Name = "User 2", Age = 19, Mail = "2@gmail.com" });
            items.Add(new User { Name = "User 3", Age = 17, Mail = "3@gmail.com" });
            lstUser.ItemsSource = items;
        }

        public class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Mail { get; set; }
        }
    }
}
