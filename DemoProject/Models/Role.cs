using System;
using System.Collections.Generic;

namespace DemoProject.Models
{
    public partial class Role
    {
        public Role()
        {
            Candidates = new HashSet<Candidate>();
            Users = new HashSet<User>();
        }

        public long RoleId { get; set; }
        public string RoleName { get; set; } = null!;

        public virtual ICollection<Candidate> Candidates { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
