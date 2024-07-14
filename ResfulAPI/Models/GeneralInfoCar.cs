using System;
using System.Collections.Generic;

namespace ResfulAPI.Models
{
    public partial class GeneralInfoCar
    {
        public int? CarId { get; set; }
        public int? NumberOfSeat { get; set; }
        public int? DesignId { get; set; }
        public string? MadeIn { get; set; }
        public string? Fuel { get; set; }
        public string? Description { get; set; }

        public virtual Car? Car { get; set; }
        public virtual CarDesign? Design { get; set; }
    }
}
