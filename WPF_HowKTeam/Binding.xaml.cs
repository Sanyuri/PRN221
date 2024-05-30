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
    /// Interaction logic for Binding.xaml
    /// </summary>
    public partial class Binding : Window, INotifyPropertyChanged
    {
        private string buttonName;
        public string ButtonName
        {
            get { return buttonName; }
            set
            {
                buttonName = value;
                OnPropertyChanged("ButtonName");
            }
        }
        public Binding()
        {
            InitializeComponent();
            this.DataContext = this;
            buttonName = "Bindind data from code behind";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
