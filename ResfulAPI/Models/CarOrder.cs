using System;
using System.Collections.Generic;

namespace ResfulAPI.Models
{
    public partial class CarOrder
    {
        public int CarorderId { get; set; }
        public string? CarorderCode { get; set; }
        public int? ClientId { get; set; }
        public int? CarId { get; set; }
        public bool? PaymentType { get; set; }
        public double? OrderValue { get; set; }
        public double? Paid { get; set; }
        public double? PaymentRequired { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public string? Status { get; set; }
        public int? VoucherId { get; set; }

        public virtual Car? Car { get; set; }
        public virtual Client? Client { get; set; }
        public virtual Account? ModifiedByNavigation { get; set; }
        public virtual Voucher? Voucher { get; set; }
    }
}
