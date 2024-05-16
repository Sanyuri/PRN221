using DemoLoadDBUsingWPF.Dtos;
using DemoLoadDBUsingWPF.Models;
using DemoLoadDBUsingWPF.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DemoLoadDBUsingWPF.ServicesImpl
{
    internal class StudentServiceImpl : StudentService
    {
        public List<StudentDTO> convertToDtoList(List<Student> students)
        {
            List<StudentDTO> studentDTOs = new List<StudentDTO>();
            foreach (Student student in students)
            {
                studentDTOs.Add(new StudentDTO()
                {
                    Id = student.Id,
                    Name = student.Name,
                    Dob = student.Dob,
                    Gender = student.Gender ? "Male" : "Female",
                    Gpa = student.Gpa,
                    Department = student.Depart.Name
                });
            }
            return studentDTOs;
        }

        public void createStudent(Student student)
        {
            try
            {
                PRN211_1Context.INSTANCE.Students.Add(student);
                PRN211_1Context.INSTANCE.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<string> getGenderList()
        {
            return PRN211_1Context.INSTANCE.Students.Select(s => s.Gender ? "Male" : "Female").Distinct().ToList();

        }

        public Student? getStudentById(int v)
        {
            return PRN211_1Context.INSTANCE.Students.Include(d => d.Depart).FirstOrDefault(s => s.Id == v);
        }

        public List<Student> getStudentList()
        {
            return PRN211_1Context.INSTANCE.Students.Include(x => x.Depart).ToList();
        }

        public List<Student> getStudentListByDepartment(string? selectedDepartment)
        {
            return PRN211_1Context.INSTANCE.Students.Include(d => d.Depart).Where(s => selectedDepartment.Equals("All") || s.Depart.Name.Equals(selectedDepartment)).ToList();
        }

        public List<Student> getStudentListByGender(string? selectedgender)
        {

            return PRN211_1Context.INSTANCE.Students.Include(d => d.Depart).Where(s => selectedgender.Equals("All") || (selectedgender.Equals("Male") ? s.Gender : !s.Gender)).ToList();
        }

        public List<Student> getStudentListByname(string? studentName)
        {
            return PRN211_1Context.INSTANCE.Students.Include(d => d.Depart).Where(s => s.Name.Contains(studentName)).ToList();
        }

        public void updateStudent(Student student)
        {
            try
            {
                PRN211_1Context.INSTANCE.Entry(student).State = EntityState.Modified;
                PRN211_1Context.INSTANCE.SaveChanges();
                MessageBox.Show($"Student with id {student.Id} has been updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
