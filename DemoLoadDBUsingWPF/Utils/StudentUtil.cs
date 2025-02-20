﻿using DemoLoadDBUsingWPF.Dtos;
using DemoLoadDBUsingWPF.Models;
using DemoLoadDBUsingWPF.Services;
using DemoLoadDBUsingWPF.ServicesImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLoadDBUsingWPF.Utils
{
    public class StudentUtil
    {
        public bool validateStudentInfo(StudentDTO student)
        {
            return validateName(student.Name)
                && validateGender(student.Gender)
                && validateDepartment(student.Department)
                && validateDoB(student.Dob)
                && validateGpa(student.Gpa);
        }

        private bool validateGpa(string mark)
        {
            if (mark.Equals(null)) return false;
            try
            {
                double gpa = Double.Parse(mark);
                return !(gpa < 0 || gpa > 10);
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        private bool validateDoB(DateTime? dob)
        {
            if(dob.Equals(null)) return false;
            return (dob < DateTime.Now);
        }

        private bool validateDepartment(string? department)
        {
            if (department == null) return false;

            DepartmentService departmentService = new DepartmentServiceImpl();
            List<string> departments = departmentService.getDepartmentNameList();
            return departments.Contains(department);
        }

        private bool validateGender(string? gender)
        {
            return !(gender == null);
        }

        private bool validateName(string fullName)
        {
            return !fullName.Equals(null);
        }
    }
}
