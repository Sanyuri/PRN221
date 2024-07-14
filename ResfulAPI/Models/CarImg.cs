using System;
using System.Collections.Generic;

namespace ResfulAPI.Models
{
    public partial class CarImg
    {
        public int? CarId { get; set; }
        public string? CarImg1 { get; set; }

        public virtual Car? Car { get; set; }
    }
}
