using System;
using System.Collections.Generic;

namespace ResfulAPI.Models
{
    public partial class EmployeeProfile
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime? Dob { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Img { get; set; }
        public bool? Gender { get; set; }
        public string? Idno { get; set; }
        public string? Address { get; set; }
        public DateTime? StartDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual Account Employee { get; set; } = null!;
    }
}
