using System;
using System.Collections.Generic;

namespace DemoProject.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            Accounts = new HashSet<User>();
        }

        public long? CandidateId { get; set; }
        public long JobId { get; set; }
        public long ScheduleId { get; set; }
        public DateTime ScheduleTime { get; set; }
        public long? StatusId { get; set; }
        public string? Location { get; set; }
        public string? MeetingUrl { get; set; }
        public string? Result { get; set; }
        public string ScheduleName { get; set; } = null!;
        public string? Note { get; set; }

        public virtual Candidate? Candidate { get; set; }
        public virtual Job Job { get; set; } = null!;
        public virtual Status? Status { get; set; }
        public virtual Offer? Offer { get; set; }

        public virtual ICollection<User> Accounts { get; set; }
    }
}
