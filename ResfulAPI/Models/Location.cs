using System;
using System.Collections.Generic;

namespace ResfulAPI.Models
{
    public partial class Location
    {
        public int LocationId { get; set; }
        public string? LocationName { get; set; }
        public double? PreRegFee { get; set; }
        public double? RegFee { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Account? CreatedByNavigation { get; set; }
        public virtual Account? ModifiedByNavigation { get; set; }
    }
}
