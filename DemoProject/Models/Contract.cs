using System;
using System.Collections.Generic;

namespace DemoProject.Models
{
    public partial class Contract
    {
        public Contract()
        {
            Offers = new HashSet<Offer>();
        }

        public long ContractId { get; set; }
        public string ContractName { get; set; } = null!;

        public virtual ICollection<Offer> Offers { get; set; }
    }
}
