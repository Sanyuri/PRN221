using System;
using System.Collections.Generic;

namespace ResfulAPI.Models
{
    public partial class ClientNumberPlate
    {
        public int ClientNumberPlateId { get; set; }
        public int? ClientId { get; set; }
        public string? NumberPlate { get; set; }

        public virtual Client? Client { get; set; }
    }
}
