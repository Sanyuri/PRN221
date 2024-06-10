using System;
using System.Collections.Generic;

namespace DemoProject.Models
{
    public partial class User
    {
        public User()
        {
            Candidates = new HashSet<Candidate>();
            Offers = new HashSet<Offer>();
            Schedules = new HashSet<Schedule>();
        }

        public bool? Gender { get; set; }
        public bool? IsActivated { get; set; }
        public long AccountId { get; set; }
        public long? DepartmentId { get; set; }
        public DateTime? Dob { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public long? RoleId { get; set; }
        public long? StatusId { get; set; }
        public string? Address { get; set; }
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Token { get; set; }
        public string? UserName { get; set; }
        public string? Note { get; set; }

        public virtual Department? Department { get; set; }
        public virtual Role? Role { get; set; }
        public virtual Status? Status { get; set; }
        public virtual ICollection<Candidate> Candidates { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
