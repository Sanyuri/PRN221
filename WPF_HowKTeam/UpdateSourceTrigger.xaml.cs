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
    /// Interaction logic for UpdateSourceTrigger.xaml
    /// </summary>
    public partial class UpdateSourceTrigger : Window, INotifyPropertyChanged
    {
        private string dataValue;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string DataValue
        {
            get { return dataValue; }
            set
            {
                string dataValue = value;
                OnPropertyChanged("DataValue");
            }
        }
        public UpdateSourceTrigger()
        {
            InitializeComponent();

            DataValue = "www.HowKTeam.com";
            this.DataContext = this;
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) new PropertyChangedEventArgs(propertyName);
        }
    }
}
