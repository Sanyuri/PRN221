using System;
using System.Collections.Generic;

namespace ResfulAPI.Models
{
    public partial class Voucher
    {
        public Voucher()
        {
            CarOrders = new HashSet<CarOrder>();
        }

        public int VoucherId { get; set; }
        public string? VoucherCode { get; set; }
        public string? Description { get; set; }
        public int? ObjectVoucherId { get; set; }
        public bool? DiscountType { get; set; }
        public double? DiscountValue { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? MaxUsage { get; set; }
        public int? UsedCount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? Status { get; set; }

        public virtual Account? CreatedByNavigation { get; set; }
        public virtual Account? ModifiedByNavigation { get; set; }
        public virtual ObjectVoucher? ObjectVoucher { get; set; }
        public virtual ICollection<CarOrder> CarOrders { get; set; }
    }
}
