using System;
using System.Collections.Generic;

namespace ResfulAPI.Models
{
    public partial class Service
    {
        public Service()
        {
            ClientServices = new HashSet<ClientService>();
        }

        public int ServiceId { get; set; }
        public string? ServiceType { get; set; }
        public string? ServiceContent { get; set; }
        public bool? ServiceStatus { get; set; }
        public double? ServicePrice { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<ClientService> ClientServices { get; set; }
    }
}
