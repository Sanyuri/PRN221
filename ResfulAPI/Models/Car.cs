using System;
using System.Collections.Generic;

namespace ResfulAPI.Models
{
    public partial class Car
    {
        public Car()
        {
            CarOrders = new HashSet<CarOrder>();
        }

        public int CarId { get; set; }
        public string? CarName { get; set; }
        public double? Price { get; set; }
        public int? BrandId { get; set; }
        public int? StatusId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual CarBrand? Brand { get; set; }
        public virtual Account? CreatedByNavigation { get; set; }
        public virtual Account? ModifiedByNavigation { get; set; }
        public virtual StatusCategory? Status { get; set; }
        public virtual ICollection<CarOrder> CarOrders { get; set; }
    }
}
