using System;
using System.Collections.Generic;

namespace DemoProject.Models
{
    public partial class Level
    {
        public Level()
        {
            Candidates = new HashSet<Candidate>();
            Offers = new HashSet<Offer>();
            Jobs = new HashSet<Job>();
        }

        public long LevelId { get; set; }
        public string LevelName { get; set; } = null!;

        public virtual ICollection<Candidate> Candidates { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
