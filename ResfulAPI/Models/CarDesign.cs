using System;
using System.Collections.Generic;

namespace ResfulAPI.Models
{
    public partial class CarDesign
    {
        public int DesignId { get; set; }
        public string? Design { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Account? CreatedByNavigation { get; set; }
        public virtual Account? ModifiedByNavigation { get; set; }
    }
}
