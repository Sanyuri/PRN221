using System;
using System.Collections.Generic;

namespace ResfulAPI.Models
{
    public partial class CarAutoPart
    {
        public int? CarId { get; set; }
        public int? AutoPartId { get; set; }

        public virtual AutoPart? AutoPart { get; set; }
        public virtual Car? Car { get; set; }
    }
}
