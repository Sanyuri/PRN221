using System;
using System.Collections.Generic;

namespace ResfulAPI.Models
{
    public partial class StatusCategory
    {
        public StatusCategory()
        {
            Cars = new HashSet<Car>();
        }

        public int StatusId { get; set; }
        public string? StatusName { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
