using System;
using System.Collections.Generic;

namespace DemoProject.Models
{
    public partial class Job
    {
        public Job()
        {
            Schedules = new HashSet<Schedule>();
            Benefits = new HashSet<Benefit>();
            Levels = new HashSet<Level>();
            Skills = new HashSet<Skill>();
        }

        public bool? IsActivated { get; set; }
        public double? SalaryMax { get; set; }
        public double? SalaryMin { get; set; }
        public DateTime EndDate { get; set; }
        public long JobId { get; set; }
        public DateTime StartDate { get; set; }
        public long? StatusId { get; set; }
        public string? Description { get; set; }
        public string JobName { get; set; } = null!;
        public string? WorkingAddress { get; set; }

        public virtual Status? Status { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }

        public virtual ICollection<Benefit> Benefits { get; set; }
        public virtual ICollection<Level> Levels { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
    }
}
