using System;
using System.Collections.Generic;

namespace DemoProject.Models
{
    public partial class Department
    {
        public Department()
        {
            Offers = new HashSet<Offer>();
            Users = new HashSet<User>();
        }

        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;

        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
