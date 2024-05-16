using DemoLoadDBUsingWPF.Models;
using DemoLoadDBUsingWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLoadDBUsingWPF.ServicesImpl
{
    internal class DepartmentServiceImpl : DepartmentService
    {
        public Department? findDepartByName(string selectedItem)
        {
            return PRN211_1Context.INSTANCE.Departments.FirstOrDefault(d => d.Name.Equals(selectedItem));
        }

        public List<string> getDepartmentNameList()
        {
            return PRN211_1Context.INSTANCE.Departments.Select(d => d.Name).ToList();
        }
    }
}
