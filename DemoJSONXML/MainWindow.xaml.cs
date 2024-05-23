using DemoJSONXML.Dtos;
using DemoJSONXML.Models;
using DemoJSONXML.Services;
using Microsoft.Win32;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace DemoJSONXML
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PersonService personService = new PersonServiceImpl();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Load(object sender, RoutedEventArgs e)
        {
            cbxGender.Items.Add("Male");
            cbxGender.Items.Add("Female");
        }
        List<Person> people = new List<Person>();
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            //Code with XML Serialization
            var ofd = new OpenFileDialog()
            { Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*" };
            var result = ofd.ShowDialog();
            if (result == false) return;
            var xs = new XmlSerializer(typeof(List<Person>));
            using Stream s2 = File.OpenRead(ofd.FileName);
            people = (List<Person>)xs.Deserialize(s2);

            ////Code with Json Serialization
            //var ofd = new OpenFileDialog()
            //{ Filter = "Json files (*.json)|*.json|All files (*.*)|*.*" };
            //var result = ofd.ShowDialog();
            //if (result == false) return;
            //var js = new DataContractJsonSerializer(typeof(List<Person>));
            //using Stream s2 = File.OpenRead(ofd.FileName);
            //people = (List<Person>)js.ReadObject(s2);

            ////Code with User Serialization
            //var ofd = new OpenFileDialog()
            //{ Filter = "Txt files (*.txt)|*.txt|All files (*.*)|*.*" };
            //var result = ofd.ShowDialog();
            //if (result == false) return;
            //using Stream s2 = File.OpenRead(ofd.FileName);
            //using StreamReader sr = new StreamReader(s2);
            //string line;
            //people = new List<Person>();
            //while ((line = sr.ReadLine()) != null)
            //{
            //    string[] arr = line.Split('|');
            //    people.Add(new Person { Id = int.Parse(arr[0]), Name = arr[1], Gender = arr[2].Equals("Male") ? true : false });
            //}


            dgDisplay.ItemsSource = personService.convertToDtoList(people);
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //Code with XML Serialization
            var sfd = new SaveFileDialog()
            { Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*" };
            var result = sfd.ShowDialog();
            if (result == false) return;
            var xs = new XmlSerializer(typeof(List<Person>));
            using Stream s2 = File.Create(sfd.FileName);
            xs.Serialize(s2, people);

            ////Code with Json Serialization
            //var sfd = new SaveFileDialog()
            //{ Filter = "Json files (*.json)|*.json|All files (*.*)|*.*" };
            //var result = sfd.ShowDialog();
            //if (result == false) return;
            //var js = new DataContractJsonSerializer(typeof(List<Person>));
            //using Stream s2 = File.Create(sfd.FileName);
            //js.WriteObject(s2, people);

            ////Code with User Serialization
            //var sfd = new SaveFileDialog()
            //{ Filter = "Txt files (*.txt)|*.txt|All files (*.*)|*.*" };
            //var result = sfd.ShowDialog();
            //if (result == false) return;
            //using Stream s2 = File.Create(sfd.FileName);
            //using StreamWriter sw = new StreamWriter(s2);
            //foreach (var p in people)
            //{
            //    String gender = p.Gender == true ? "Male" : "Female";
            //    sw.WriteLine($"{p.Id}|{p.Name}|{gender}");
            //}
            //sw.Close();
            s2.Close();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var x = people.FirstOrDefault(p => p.Id == id);
            if(x != null)
            {
                MessageBox.Show("Id already exists");
                return;
            }
            string name = txtName.Text;
            bool gender = cbxGender.Text.Equals("Male")? true : false;
            people.Add(new Person { Id = id, Name = name, Gender = gender });
            dgDisplay.ItemsSource = personService.convertToDtoList(people);
            dgDisplay.Items.Refresh();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var x = people.FirstOrDefault(p => p.Id == id);
            if (x == null)
            {
                MessageBox.Show("Id does not exist");
                return;
            }
            x.Name = txtName.Text;
            x.Gender = cbxGender.Text.Equals("Male") ? true : false;
            dgDisplay.ItemsSource = personService.convertToDtoList(people);
            dgDisplay.Items.Refresh();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var x = people.FirstOrDefault(p => p.Id == id);
            if (x == null)
            {
                MessageBox.Show("Id does not exist");
                return;
            }
            people.Remove(x);
            dgDisplay.ItemsSource = personService.convertToDtoList(people);
            dgDisplay.Items.Refresh();
        }

        private void dgDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgDisplay.SelectedIndex < 0) return;
            var x = (PersonDto)dgDisplay.SelectedItem;
            txtId.Text = x.Id.ToString();
            txtName.Text = x.Name;
            cbxGender.Text = x.Gender;
        }

        //filter
        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = txtFilter.Text;
            dgDisplay.ItemsSource = personService.convertToDtoList(people.Where(p => p.Name.ToLower().Contains(filter.ToLower())).ToList());
            dgDisplay.Items.Refresh();
        }
    }
}