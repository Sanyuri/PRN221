using System;
using System.Collections.Generic;

namespace ResfulAPI.Models
{
    public partial class InFoInvoiceDetail
    {
        public int InfoDetailId { get; set; }
        public int ServiceInvoiceId { get; set; }
        public string? ProductName { get; set; }
        public string? UnitPrice { get; set; }
        public string? Quantity { get; set; }

        public virtual HistoryServiceInvoice ServiceInvoice { get; set; } = null!;
    }
}
