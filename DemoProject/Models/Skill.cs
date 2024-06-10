using System;
using System.Collections.Generic;

namespace DemoProject.Models
{
    public partial class Skill
    {
        public Skill()
        {
            Candidates = new HashSet<Candidate>();
            Jobs = new HashSet<Job>();
        }

        public long SkillId { get; set; }
        public string SkillName { get; set; } = null!;

        public virtual ICollection<Candidate> Candidates { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
