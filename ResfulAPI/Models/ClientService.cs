using System;
using System.Collections.Generic;

namespace ResfulAPI.Models
{
    public partial class ClientService
    {
        public int ClientServiceId { get; set; }
        public int? ClientId { get; set; }
        public int? ServiceId { get; set; }
        public string? NumberPlate { get; set; }
        public DateTime? DateService { get; set; }
        public int? BrandId { get; set; }
        public string? Status { get; set; }
        public int? EmployeeId { get; set; }
        public int? CrewChiefId { get; set; }

        public virtual CarBrand? Brand { get; set; }
        public virtual Client? Client { get; set; }
        public virtual Service? Service { get; set; }
    }
}
