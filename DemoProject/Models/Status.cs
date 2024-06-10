using System;
using System.Collections.Generic;

namespace DemoProject.Models
{
    public partial class Status
    {
        public Status()
        {
            Candidates = new HashSet<Candidate>();
            Jobs = new HashSet<Job>();
            Offers = new HashSet<Offer>();
            Schedules = new HashSet<Schedule>();
            Users = new HashSet<User>();
        }

        public long StatusId { get; set; }
        public string? StatusName { get; set; }

        public virtual ICollection<Candidate> Candidates { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
