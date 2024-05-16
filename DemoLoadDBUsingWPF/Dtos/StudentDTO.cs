using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLoadDBUsingWPF.Dtos
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public string? Department { get; set; }
        public DateTime? Dob { get; set; }
        public double Gpa { get; set; }
    }
}
