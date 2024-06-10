using System;
using System.Collections.Generic;

namespace DemoProject.Models
{
    public partial class Position
    {
        public Position()
        {
            Candidates = new HashSet<Candidate>();
            Offers = new HashSet<Offer>();
        }

        public long PositionId { get; set; }
        public string PositionName { get; set; } = null!;

        public virtual ICollection<Candidate> Candidates { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
    }
}
