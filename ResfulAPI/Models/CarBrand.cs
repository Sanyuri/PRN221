using System;
using System.Collections.Generic;

namespace ResfulAPI.Models
{
    public partial class CarBrand
    {
        public CarBrand()
        {
            Cars = new HashSet<Car>();
            ClientServices = new HashSet<ClientService>();
        }

        public int BrandId { get; set; }
        public string? BrandName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public string? BrandImg { get; set; }

        public virtual Account? CreatedByNavigation { get; set; }
        public virtual Account? ModifiedByNavigation { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<ClientService> ClientServices { get; set; }
    }
}
