using System;
using System.Collections.Generic;

namespace ResfulAPI.Models
{
    public partial class HistoryServiceInvoice
    {
        public HistoryServiceInvoice()
        {
            InFoInvoiceDetails = new HashSet<InFoInvoiceDetail>();
        }

        public int ServiceInvoiceId { get; set; }
        public int? ClientServiceId { get; set; }
        public DateTime? DateComplete { get; set; }
        public string? Feedback { get; set; }

        public virtual ICollection<InFoInvoiceDetail> InFoInvoiceDetails { get; set; }
    }
}
