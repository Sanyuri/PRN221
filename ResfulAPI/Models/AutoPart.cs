using System;
using System.Collections.Generic;

namespace ResfulAPI.Models
{
    public partial class AutoPart
    {
        public int AutoPartId { get; set; }
        public string? PartName { get; set; }
        public double? Price { get; set; }
        public string? PartImg { get; set; }
        public bool? Status { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Account? CreatedByNavigation { get; set; }
        public virtual Account? ModifiedByNavigation { get; set; }
    }
}
