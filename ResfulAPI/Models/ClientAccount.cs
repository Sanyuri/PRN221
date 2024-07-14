using System;
using System.Collections.Generic;

namespace ResfulAPI.Models
{
    public partial class ClientAccount
    {
        public int AccId { get; set; }
        public string? Email { get; set; }
        public string? Pass { get; set; }
        public bool? Status { get; set; }

        public virtual Client Acc { get; set; } = null!;
    }
}
