using System;
using System.Collections.Generic;

namespace ResfulAPI.Models
{
    public partial class ObjectVoucher
    {
        public ObjectVoucher()
        {
            Vouchers = new HashSet<Voucher>();
        }

        public int ObjectVoucherId { get; set; }
        public string? ObjectVoucher1 { get; set; }

        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
