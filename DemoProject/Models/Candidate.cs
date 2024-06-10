using System;
using System.Collections.Generic;

namespace DemoProject.Models
{
    public partial class Candidate
    {
        public Candidate()
        {
            Offers = new HashSet<Offer>();
            Schedules = new HashSet<Schedule>();
            Skills = new HashSet<Skill>();
        }

        public bool? Gender { get; set; }
        public bool? IsActivated { get; set; }
        public long AccountId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? Dob { get; set; }
        public long? HighestLevel { get; set; }
        public long? PositionId { get; set; }
        public long RecruiterId { get; set; }
        public long? RoleId { get; set; }
        public long? StatusId { get; set; }
        public string? Address { get; set; }
        public string? CvAttachment { get; set; }
        public string Email { get; set; } = null!;
        public string? ExpYear { get; set; }
        public string FullName { get; set; } = null!;
        public string? ModifiedBy { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Note { get; set; }

        public virtual Level? HighestLevelNavigation { get; set; }
        public virtual Position? Position { get; set; }
        public virtual User Recruiter { get; set; } = null!;
        public virtual Role? Role { get; set; }
        public virtual Status? Status { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }
    }
}
