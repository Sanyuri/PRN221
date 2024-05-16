using DemoLoadDBUsingWPF.Dtos;
using DemoLoadDBUsingWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLoadDBUsingWPF.Services
{
    public interface StudentService
    {
        List<StudentDTO> convertToDtoList(List<Student> students);
        void createStudent(Student student);
        List<string> getGenderList();
        Student? getStudentById(int v);
        List<Student> getStudentList();
        List<Student> getStudentListByDepartment(string? selectedDepartment);
        List<Student> getStudentListByGender(string? selectedgender);
        List<Student> getStudentListByname(string? studentName);
        void updateStudent(Student student);
    }
}
