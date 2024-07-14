using System;
using System.Collections.Generic;

namespace ResfulAPI.Models
{
    public partial class TestDriveService
    {
        public int TestDriveServiceId { get; set; }
        public int? ClientId { get; set; }
        public int? CarId { get; set; }
        public DateTime? DateService { get; set; }
        public string? Status { get; set; }
        public int? EmployeeId { get; set; }
    }
}
