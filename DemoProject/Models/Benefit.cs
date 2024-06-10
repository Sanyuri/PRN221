using System;
using System.Collections.Generic;

namespace DemoProject.Models
{
    public partial class Benefit
    {
        public Benefit()
        {
            Jobs = new HashSet<Job>();
        }

        public long BenefitId { get; set; }
        public string BenefitName { get; set; } = null!;

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
