using System;
using System.Collections.Generic;

namespace DemoProject.Models
{
    public partial class Offer
    {
        public Offer()
        {
            Accounts = new HashSet<User>();
        }

        public double Slary { get; set; }
        public long? CandidateId { get; set; }
        public DateTime ContractFrom { get; set; }
        public long? ContractId { get; set; }
        public DateTime ContractTo { get; set; }
        public long? DepartmentId { get; set; }
        public DateTime DueDate { get; set; }
        public long? LevelId { get; set; }
        public long OfferId { get; set; }
        public long? PositionId { get; set; }
        public long? ScheduleId { get; set; }
        public long? StatusId { get; set; }
        public string? Note { get; set; }

        public virtual Candidate? Candidate { get; set; }
        public virtual Contract? Contract { get; set; }
        public virtual Department? Department { get; set; }
        public virtual Level? Level { get; set; }
        public virtual Position? Position { get; set; }
        public virtual Schedule? Schedule { get; set; }
        public virtual Status? Status { get; set; }

        public virtual ICollection<User> Accounts { get; set; }
    }
}
