using System.Configuration;
using System.Reflection;
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
using DemoLoadDBUsingWPF.Dtos;
using DemoLoadDBUsingWPF.Models;
using DemoLoadDBUsingWPF.Services;
using DemoLoadDBUsingWPF.ServicesImpl;
using DemoLoadDBUsingWPF.Utils;
using Microsoft.EntityFrameworkCore;

namespace DemoLoadDBUsingWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public StudentService studentService = new StudentServiceImpl();
        public DepartmentService departmentService = new DepartmentServiceImpl();
        public StudentUtil studentUtil = new StudentUtil();
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
            List<Student> students = studentService.getStudentList();
            List<StudentDTO> studentDTOs = studentService.convertToDtoList(students);
            dgvDisplay.ItemsSource = studentDTOs;

            List<String> departments = departmentService.getDepartmentNameList();
            departments.Insert(0, "All");
            cbxDepart.ItemsSource = departments;
            List<String> genders = studentService.getGenderList();
            genders.Insert(0, "All");
            cbxGender.ItemsSource = genders;

            cbxDepartment.ItemsSource = departmentService.getDepartmentNameList();
            cbxGenderInfo.ItemsSource = studentService.getGenderList();
        }
        private void filterByDepartment(object sender, RoutedEventArgs e)
        {
            String? selectedDepartment = cbxDepart.SelectedItem.ToString();
            List<Student> students = studentService.getStudentListByDepartment(selectedDepartment);
            dgvDisplay.ItemsSource = studentService.convertToDtoList(students);
        }
        private void filterByGender(object sender, RoutedEventArgs e)
        {
            String? selectedgender = cbxGender.SelectedItem.ToString();
            List<Student> students = studentService.getStudentListByGender(selectedgender);
            dgvDisplay.ItemsSource = studentService.convertToDtoList(students);
        }

        private void searchStudent(object sender, TextChangedEventArgs e)
        {
            String? studentName = txtSearch.Text;
            List<Student> students = studentService.getStudentListByname(studentName);
            dgvDisplay.ItemsSource = studentService.convertToDtoList(students);
        }

        private void dgvDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //StudentDTO selectedStudent = (StudentDTO)dgvDisplay.SelectedItem;
            //if (selectedStudent != null)
            //{
            //    txtId.Text = selectedStudent.Id.ToString();
            //    txtFullName.Text = selectedStudent.Name?.ToString();
            //    cbxGenderInfo.SelectedItem = selectedStudent.Gender?.ToString();
            //    cbxDepartment.SelectedItem = selectedStudent.Department?.ToString();
            //    dpkDob.Text = selectedStudent.Dob.ToString();
            //    txtGpa.Text = selectedStudent.Gpa.ToString();
            //}
        }

        private StudentDTO GetStudentDTO()
        {
            return new StudentDTO
            {
                Id = txtId.Text,
                Name = txtFullName.Text,
                Department = cbxDepartment.SelectedItem?.ToString(),
                Dob = dpkDob.SelectedDate,
                Gender = cbxGenderInfo.SelectedItem?.ToString(),
                Gpa = txtGpa.Text
            };
        }

        private void createStudent(object sender, RoutedEventArgs e)
        {
            StudentDTO studentDTO = GetStudentDTO();

            Boolean isValidatedStudent = studentUtil.validateStudentInfo(studentDTO);
            List<Student> students = studentService.getStudentList();
            //get last student in list
            Student lastStudent = students.LastOrDefault();
            if (isValidatedStudent)
            {
                Student student = new Student()
                {
                    Id = lastStudent.Id + 1,
                    Name = studentDTO.Name,
                    Gender = studentDTO.Gender.Equals("Male") ? true : false,
                    Depart = departmentService.findDepartByName(studentDTO.Department),
                    Dob = studentDTO.Dob,
                    Gpa = Double.Parse(studentDTO.Gpa)
                };
                studentService.createStudent(student);
                Load();
            }
            else
            {
                MessageBox.Show("Student's information invalid");
            }
        }

        private void updateStudent(object sender, RoutedEventArgs e)
        {
            StudentDTO studentDTO = GetStudentDTO();

            Boolean isValidatedStudent = studentUtil.validateStudentInfo(studentDTO);

            if (isValidatedStudent)
            {
                Student? student = studentService.getStudentById(int.Parse(studentDTO.Id));
                student.Name = studentDTO.Name;
                student.Gender = studentDTO.Gender.Equals("Male") ? true : false;
                student.Depart = departmentService.findDepartByName(studentDTO.Department);
                student.Dob = studentDTO.Dob;
                student.Gpa = Double.Parse(studentDTO.Gpa);

                studentService.updateStudent(student);
                Load();
            }
            else
            {
                MessageBox.Show("Student's information invalid");
            }
        }

        private void deleteStudent(object sender, RoutedEventArgs e)
        {
            StudentDTO studentDTO = GetStudentDTO();
            Student? student = studentService.getStudentById(int.Parse(studentDTO.Id));
            if (student != null)
            {
                studentService.deleteStudent(student);
                MessageBox.Show("Student deleted");
                Load();
            }
            else
            {
                MessageBox.Show("Student not found");
            }
        }
    }
}